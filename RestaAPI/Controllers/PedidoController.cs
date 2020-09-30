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
    public class PedidoController : ControllerBase
    {
        private readonly RestauranteContext _context;

        public PedidoController(RestauranteContext context)
        {
            _context = context;
        }

        // GET: api/Pedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        // GET: api/Pedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // PUT: api/Pedido/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.PedidoId)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
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

        // POST: api/Pedido
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedido", new { id = pedido.PedidoId }, pedido);
        }
        
        // DELETE: api/Pedido/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedido>> DeletePedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

        //8. GET: api/pedido/producto/6
        [HttpDelete("producto/{id}")]
        public Pedido DeletePedidoConIntermedia(int id)
        {

            var pedido = _context.Pedidos.Find(id);
            var pedidoProd = _context.ProductoPedidos.FromSqlRaw(string.Format("SELECT * FROM ProductoPedidos where PedidoId = {0}",id)).ToList();

            if(pedido != null && pedidoProd != null)
            {
                
                _context.ProductoPedidos.RemoveRange(pedidoProd);
                _context.Pedidos.Remove(pedido);
                _context.SaveChanges();
                
            }

            return pedido;

        }

        //5. GET: api/Pedido/mesa/6
        [HttpGet("Mesa/{id}")]
        public List<Pedido> getByMesa(int id){
            //bool flag =  PedidoExists(id);
            List<Pedido> encontrados = new List<Pedido>(); 
       
       
            var query = _context.Pedidos.FromSqlRaw(string.Format("select *from Pedidos where MesaId  ={0}",id.ToString()));
            encontrados = query.ToList();
            
            
            
          
         

            return encontrados;
            
        }

        
        //Devuelve el total de facturacion de un pedido
        //9. get: api/pedido/facturacion
        [HttpGet("Facturacion/{id}")]
        public double calcFacturacion(int id)
        {
         

            
            double total = 0 ;
            
            foreach(ProductoPedido pp in _context.ProductoPedidos.Where(p => p.PedidoId ==id).ToList())
            {
                var producto = _context.Productos.Find(pp.ProductoId);
                total += producto.Precio;

            }
            return total;
            

        }

        //10. Get api/pedido/cliente/5
        [HttpGet("cliente/{id}")]
        public List<Pedido> pedidosPorCliente(int id){
            var query = _context.Pedidos.FromSqlRaw(string.Format("SELECT * FROM pedidos where clienteId = {0}",id)).ToList();

            return query;
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.PedidoId == id);
        }
    }
}
