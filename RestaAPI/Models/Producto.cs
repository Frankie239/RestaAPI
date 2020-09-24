using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaAPI.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId;

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
        public string Tipo;
        public string Nombre;
        public  List<Ingrediente> Ingredientes;

       

        
    }
}