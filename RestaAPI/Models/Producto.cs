using System.Collections.Generic;

namespace RestaAPI.Models
{
    public class Producto
    {
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