using ControleEstoque.Domain.Commands.ItemProducts;

namespace ControleEstoque.Domain.Validations.ItemProducts
{
    public class RemoveItemProductCommandValidation : ItemProductValidation<RemoveItemProductCommand>
    {
        public RemoveItemProductCommandValidation()
        {
            ValidateIdItem();
            ValidateIdProduct();
        }
    }
}
