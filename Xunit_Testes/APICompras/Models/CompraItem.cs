using System.ComponentModel.DataAnnotations;

namespace APICompras.Models
{
    public class CompraItem
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Fabricante { get; set; }
    }
}
