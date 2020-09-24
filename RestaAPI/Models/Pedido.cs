using System.Collections.Generic;

using System;
using System.ComponentModel.DataAnnotations;

namespace RestaAPI.Models
{
    public class Pedido
    {

        [Key]
        public int PedidoId{set;get;}
        List<Producto> Productos;
        private int facturacion;
         public Mozo Vendedor{set;get;} 
        public Cliente comprador {set;get;}
        public DateTime Fecha {set;get;}
        
        public Mesa mesa {set;get;}


    }
}