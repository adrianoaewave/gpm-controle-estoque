using ControleEstoque.Domain.Validations.ItemProducts;

namespace ControleEstoque.Domain.Commands.ItemProducts
{
    public class UpdateItemProductCommand : ItemProductCommand
    {
        public UpdateItemProductCommand(int idItem, int idProduct, int itemProductQuantity)
        {
            IdItem = idItem;
            IdProduct = idProduct;
            ItemProductQuantity = itemProductQuantity;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateItemProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
