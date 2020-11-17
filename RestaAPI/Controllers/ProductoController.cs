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
    public class ProductoController : ControllerBase
    {
        private readonly RestauranteContext _context;

        public ProductoController(RestauranteContext context)
        {
            _context = context;
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos
            .Include(p => p.ProductoPedidos)
            .Include(p => p.ProductoIngredientes)
            .ToListAsync();
        }


        // GET: api/Producto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos
            .Include(p => p.ProductoPedidos)
            .Include(p => p.ProductoIngredientes)
            .FirstOrDefaultAsync(p => p.ProductoId == id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/Producto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.ProductoId)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
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

        // POST: api/Producto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducto", new { id = producto.ProductoId }, producto);
        }

        // DELETE: api/Producto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Producto>> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return producto;
        }

        //6. GET: api/producto/ProdMasPedido


        [HttpGet("ProdMasPedido")]
        public Producto ProdMasPedido(){
             
            var query  = _context.Productos
            .FromSqlRaw("select top 1 * from Productos where EXISts  (select top 1 count(PedidoId), ProductoId from ProductoPedidos group by ProductoId )")
            .Include(p => p.ProductoPedidos)
            .Include(p => p.ProductoIngredientes)
            .ToList();

            if(query != null){
                foreach(Producto prod in query){
                return prod;
                }   
            }
            else{
                return null;
            }
            return null;
            
            
        }
        //Trae los productos por pedido
        //7.GET: api/pedido/6
        [HttpGet("pedido/{id}")]
        public List<Producto> ProdByPedido(int id){
            var query = _context.Productos
            .FromSqlRaw(string.Format("select productoId, precio, Tipo, Nombre from Productos where ProductoId in (select ProductoId from ProductoPedidos where PedidoId ={0})",id.ToString()))
            .Include(p => p.ProductoPedidos)
            .Include(p => p.ProductoIngredientes)
            .ToList();
            
            return query;
        }

        //Post: api/producto/1/pedido/1
        [HttpPost("{ProdId:int}/pedido/{PedidoId:int}")]

        public void InsertarProdPedido( int ProdId, int PedidoId)
        {
            ProductoPedido pp = new ProductoPedido();
            pp.PedidoId = PedidoId;
            pp.ProductoId = ProdId;

            _context.ProductoPedidos.Add(pp);
            _context.SaveChanges();
            
           


        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.ProductoId == id);
        }
    }
}
