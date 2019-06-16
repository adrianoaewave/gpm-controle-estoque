using ControleEstoque.Domain.Validations.ItemProducts;

namespace ControleEstoque.Domain.Commands.ItemProducts
{
    public class RegisterNewItemProductCommand : ItemProductCommand
    {
        public RegisterNewItemProductCommand(int idItem, int idProduct, int itemProductQuantity)
        {
            IdItem = idItem;
            IdProduct = idProduct;
            ItemProductQuantity = itemProductQuantity;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewItemProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
