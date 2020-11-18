using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestaAPI.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId {set;get;}

        private double _precio; 
        public double Precio 
        {
            set
            {
                if(value>= 0)
                    _precio = value;
                
                

            }
            get{return _precio;}
        }
        public string Tipo{set;get;}
        public string Nombre{set;get;}

        [JsonIgnore]
        public virtual IEnumerable<ProductoIngrediente> ProductoIngredientes{set;get;}
        [JsonIgnore]
        public virtual IEnumerable<ProductoPedido> ProductoPedidos{set;get;}

       

        
    }
}