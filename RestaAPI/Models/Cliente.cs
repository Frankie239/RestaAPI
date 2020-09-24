using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaAPI.Models
{
    public class Cliente : IPersona
    {
        [Key]
        public string Id { get; set; }
        public List<Mesa> mesas {get;set;}
        public virtual Pedido pedido {get;set;}

        public double Cuenta()
        {
            throw new System.NotImplementedException();
        }
    }
}