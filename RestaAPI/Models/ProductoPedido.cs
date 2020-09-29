using System.ComponentModel.DataAnnotations;

namespace RestaAPI.Models
{
    public class ProductoPedido
    {
        [Key]
        public int ProductoPedidoId {set;get;}

        public int ProductoId {set;get;}
        public virtual Producto Producto {set;get;}

        public int PedidoId {set;get;}
        public virtual Pedido Pedido {set;get;}

        

    }
}