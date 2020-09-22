using System.Collections.Generic;

namespace RestaAPI.Models
{
    public class Cliente : IPersona
    {
        public string Id { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public List<Mesa> mesas { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Pedido pedido { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public double Cuenta()
        {
            throw new System.NotImplementedException();
        }
    }
}