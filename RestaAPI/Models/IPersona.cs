using System.Collections.Generic;
namespace RestaAPI.Models
{
    public interface IPersona
    {
        string Id {set;get;}

        double Cuenta();

        List<Mesa> mesas {set;get;}

        Pedido pedido {set;get;}




    }
}