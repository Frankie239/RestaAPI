using System.Collections.Generic;

using System;
using System.ComponentModel.DataAnnotations;

namespace RestaAPI.Models
{
    public class Pedido
    {

        [Key]
        public int PedidoId{set;get;}
        public IEnumerable<ProductoPedido> ProductoPedidos {set;get;}
        private int facturacion;
        
        public virtual Cliente Cliente {set;get;}
        public  virtual Mesa Mesa {set;get;}
        public DateTime Fecha {set;get;}
        
        
        



    }
}