using System.Collections.Generic;

namespace RestaAPI.Models
{
    public class Mozo : IPersona
    {
        public string Id { get; set; }
        public List<Mesa> mesas { get; set; }
        public Pedido pedido { get; set; }

        //Calcular la facturacion, como este lado es el del dueño, es un metodo distinto al del cliente en donde solo se muestra la cantidad total.
        public double Cuenta()
        {
            throw new System.NotImplementedException();
        }
    }
}