using ControleEstoque.Domain.Validations.ItemProducts;

namespace ControleEstoque.Domain.Commands.ItemProducts
{
    public class RemoveItemProductCommand : ItemProductCommand
    {
        public RemoveItemProductCommand(int idItem, int idProduct)
        {
            IdItem = idItem;
            IdProduct = idProduct;

        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveItemProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
