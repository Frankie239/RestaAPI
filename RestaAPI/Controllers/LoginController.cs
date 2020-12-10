using System;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

//Para controladores
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using RestaAPI.Models;
using System.Linq;

namespace RestaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController:ControllerBase
    {
        private readonly RestauranteContext _context;

       
        private readonly IConfiguration _config;

        public LoginController(IConfiguration config,RestauranteContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost]
        [AllowAnonymous]
        /// <summary>
        /// Action controller to log a user.
        /// </summary>
        /// <param name="login">the user object to log in</param>
        /// <returns></returns>
        public IActionResult Login([FromBody] User login)
        {
            IActionResult response = Unauthorized();
            User user = Autenthicate(login);
            if(user != null)
            {
                var tokenString = GenerateToken(user);
                response = Ok(new {token = tokenString,userDetails = user});
            }
            return response;
        }

        /// <summary>
        /// Method that validates that the user already exists in the database
        /// </summary>
        /// <param name="credentials">the ojbect that contains the user credentials to compare into the database</param>
        /// <returns></returns>
        private User Autenthicate (User credentials)
        {
            //Validates into the database
            
            var  validatedUser = _context.Users
            .Where(u => u.UserName == credentials.UserName && u.Password == credentials.Password)
            .First();
            
            /*
            var UsuarioValidad = new Models.User(){
                FullName = "Juan Perez",
                UserRole = "Admin",
                UserName = "Juan2103"
            };
            */
            return validatedUser;
            
        }

        private string GenerateToken(User UserInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:SecretKey"]));
            //!FALTA VER ESTO
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var claims = new []
            {
                new Claim (JwtRegisteredClaimNames.Sub, UserInfo.UserName),
                new Claim("fullName",UserInfo.FullName.ToString()),
                new Claim("Role", UserInfo.UserRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                issuer:_config["Jwt:Issuer"],
                audience:_config["Jwt:Audience"],
                claims:claims,
                expires:DateTime.Now.AddMinutes(30),
                signingCredentials:credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}