using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace RestaAPI.Models
{
    public class Mesa
    {
        [Key]
        public int MesaId {set;get;}

        public string NumeroDeMesa {set;get;}
        public List<Pedido> pedidos {set;get;}

        
    }
}