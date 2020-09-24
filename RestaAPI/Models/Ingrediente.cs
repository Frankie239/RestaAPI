using System.ComponentModel.DataAnnotations;
namespace RestaAPI.Models
{
    public class Ingrediente
    {
        
        public int IngredienteId {set;get;}
        public string Nombre{set;get;}
        public int Cantidad{set;get;}

        
    }
}