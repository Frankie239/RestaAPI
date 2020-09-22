using System.Collections.Generic;
namespace RestaAPI.Models
{
    public class Pedido
    {

        List<Producto> Productos;
        private int facturacion;
         public Mozo Vendedor{set;get;} 
        public Cliente comprador {set;get;}
        
        public Mesa mesa {set;get;}


    }
}