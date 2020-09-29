using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; 
namespace RestaAPI.Models
{
    public class Ingrediente
    {
        
        public int IngredienteId {set;get;}
        public string Nombre{set;get;}
        public int Cantidad{set;get;}

        public virtual IEnumerable<ProductoIngrediente> ProductoIngredientes{set;get;}
        

        
    }
}