using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestaAPI.Models
{
    public class ProductoPedido
    {
        [Key]
        public int ProductoPedidoId {set;get;}

        public int ProductoId {set;get;}
        [JsonIgnore]
        public virtual Producto Producto {set;get;}

        public int PedidoId {set;get;}
        [JsonIgnore]
        public virtual Pedido Pedido {set;get;}

        

    }
}