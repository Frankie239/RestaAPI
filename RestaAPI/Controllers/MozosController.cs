using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaAPI.Models;

namespace RestaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MozosController : ControllerBase
    {
        private readonly RestauranteContext _context;

        public MozosController(RestauranteContext context)
        {
            _context = context;
        }

        //Get: api/Mozos/conMasPedido
        [HttpGet("maxSalario")]
        ///Devuelve el mozo con el salario mas alto 
        public Mozo MejorPago(){
           
          
           var mozo = _context.Mozos.FromSqlRaw("select * from Mozos where Salario in(select max(salario) from Mozos)").ToList();
           
           foreach(Mozo encontra3 in mozo){
               return encontra3;
           }
           
           return null;
           

        }
        //GET: api/masPedidos
        [HttpGet("masPedidos")]
        public Mozo MasPedidos(){
            var mozos = _context.Mozos.FromSqlRaw(" select * from Mozos where Mozos.Id  in(select top 1 MozoId From Pedidos group by MozoId order by count(MozoId) DESC)").ToList();
            foreach(Mozo mozo in mozos ){
                return mozo;
            }
            return null;
        }

        // GET: api/Mozos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mozo>>> GetMozos()
        {
            return await _context.Mozos.ToListAsync();
        }

        // GET: api/Mozos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mozo>> GetMozo(string id)
        {
            var mozo = await _context.Mozos.FindAsync(id);

            if (mozo == null)
            {
                return NotFound();
            }

            return mozo;
        }

        // PUT: api/Mozos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMozo(string id, Mozo mozo)
        {
            if (id != mozo.Id)
            {
                return BadRequest();
            }

            _context.Entry(mozo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MozoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Mozos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Mozo>> PostMozo(Mozo mozo)
        {
            _context.Mozos.Add(mozo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MozoExists(mozo.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMozo", new { id = mozo.Id }, mozo);
        }

        // DELETE: api/Mozos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mozo>> DeleteMozo(string id)
        {
            var mozo = await _context.Mozos.FindAsync(id);
            if (mozo == null)
            {
                return NotFound();
            }

            _context.Mozos.Remove(mozo);
            await _context.SaveChangesAsync();

            return mozo;
        }

        private bool MozoExists(string id)
        {
            return _context.Mozos.Any(e => e.Id == id);
        }
    }
}
