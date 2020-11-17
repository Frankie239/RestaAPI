using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestaAPI.Models
{
    public class Mesa
    {
        
        public int MesaId {set;get;}

        public string NumeroDeMesa {set;get;}

        public string Estado {set;get;}
        
        
     
        public List<Pedido> pedidos {set;get;}

        
    }
}