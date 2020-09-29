using System.ComponentModel.DataAnnotations;

namespace RestaAPI.Models
{
    public class ProductoIngrediente
    {
        [Key]
        public int ProductoIngredienteId {set;get;}
        public int productoId{set;get;}
        public virtual Producto Producto{set;get;}

        public int ingredienteId {set;get;}
        public virtual Ingrediente Ingrediente {set;get;}
    }
}