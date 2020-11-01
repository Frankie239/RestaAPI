using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestaAPI.Models
{
    public class Mesa
    {
        [Key]
        public int MesaId {set;get;}

        public string NumeroDeMesa {set;get;}
        
        [JsonIgnore]
        public List<Pedido> pedidos {set;get;}

        
    }
}