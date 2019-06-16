using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Application.ViewModels
{
    public class ItemViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Quantidade Estoque is Required")]
        [DisplayName("Quantidade Estoque")]
        public int QuantidadeEstoque { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("ERP Code")]
        public string ERPCode { get; set; }
    }
}
