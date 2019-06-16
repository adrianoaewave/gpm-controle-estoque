using ControleEstoque.Domain.Commands.ItemProducts;

namespace ControleEstoque.Domain.Validations.ItemProducts
{
    public class RegisterNewItemProductCommandValidation : ItemProductValidation<RegisterNewItemProductCommand>
    {
        public RegisterNewItemProductCommandValidation()
        {
            ValidateIdItem();
            ValidateIdProduct();
            ValidateItemProductQuantity();
        }
    }
}
