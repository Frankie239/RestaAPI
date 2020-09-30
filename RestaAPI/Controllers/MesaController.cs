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
    public class MesaController : ControllerBase
    {
        private readonly RestauranteContext _context;

        public MesaController(RestauranteContext context)
        {
            _context = context;
        }

        // GET: api/Mesa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mesa>>> GetMesas()
        {
            return await _context.Mesas.ToListAsync();
        }

        // GET: api/Mesa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mesa>> GetMesa(int id)
        {
            var mesa = await _context.Mesas.FindAsync(id);

            if (mesa == null)
            {
                return NotFound();
            }

            return mesa;
        }



        // PUT: api/Mesa/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMesa(int id, Mesa mesa)
        {
            if (id != mesa.MesaId)
            {
                return BadRequest();
            }

            _context.Entry(mesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MesaExists(id))
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

        // POST: api/Mesa
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Mesa>> PostMesa(Mesa mesa)
        {
            _context.Mesas.Add(mesa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMesa", new { id = mesa.MesaId }, mesa);
        }

        // DELETE: api/Mesa/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mesa>> DeleteMesa(int id)
        {
            var mesa = await _context.Mesas.FindAsync(id);
            if (mesa == null)
            {
                return NotFound();
            }

            _context.Mesas.Remove(mesa);
            await _context.SaveChangesAsync();

            return mesa;
        }

        //2. Get: api/mesa/masPopular 
        [HttpGet("MasPopular")]
        public Mesa MesaMasPopular(){
            var query = _context.Mesas.FromSqlRaw("select * from Mesas where MesaId  in(select top 1 MesaId From Pedidos group by MesaId order by count(MozoId) DESC)").ToList();
            foreach(Mesa mesa in query){
                return mesa;
            }
            return null;
            
        }

        private bool MesaExists(int id)
        {
            return _context.Mesas.Any(e => e.MesaId == id);
        }
    }
}
