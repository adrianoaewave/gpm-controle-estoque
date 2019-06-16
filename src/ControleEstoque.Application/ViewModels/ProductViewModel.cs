using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Application.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The ERP Code is Required")]
        [MinLength(2)]
        [MaxLength(20)]
        [DisplayName("ERP Code")]
        public string ERPCode { get; set; }
    }
}
