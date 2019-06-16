using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Application.ViewModels
{
    public class ItemProductViewModel
    {
        [Required(ErrorMessage = "The Item is Required")]
        public int IdItem { get; set; }

        [Required(ErrorMessage = "The Product is Required")]
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "The Quantity is Required")]
        public int ItemProductQuantity { get; set; }
    }
}
