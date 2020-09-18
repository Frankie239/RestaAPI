using System.Collections.Generic;

namespace RestaAPI.Models
{
    public abstract class Producto
    {

        private double _precio; 
        public double Precio 
        {
            set
            {
                if(value> 0)
                    _precio = value;
                

            }
            get{return _precio;}
        }
        public string Nombre;
        public  List<Ingrediente> Ingredientes;

        
    }
}