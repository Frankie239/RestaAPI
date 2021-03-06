using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SpaServices.AngularCli;
namespace RestaAPI
{
    public class Startup
    {
                public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddOpenApiDocument(configure=>{
                configure.Title = "RestauranteAPI";
            });

            
            services.AddDbContext<Models.RestauranteContext>
            (
                o => o.UseSqlServer(
                    Configuration.GetConnectionString("RestauranteConnectionString")
                )
            );

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "Restaurante/dist";
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
                options => 
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
                    };
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            //For the token validation to work
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
           
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "Restaurante";
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

        }
    }
}
