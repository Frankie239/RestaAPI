using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaAPI.Models
{
    public class Cliente
    {
        [Key]
        public string Id { get; set; }

        public string MedioDePagoPreferido {set;get;}
      

        public double Cuenta()
        {
            throw new System.NotImplementedException();
        }
    }
}