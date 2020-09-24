using System.ComponentModel.DataAnnotations;
namespace RestaAPI.Models
{
    public class Mesa
    {
        [Key]
        int mesaId;

        Cliente cliente;

        Mozo mozo;
    }
}