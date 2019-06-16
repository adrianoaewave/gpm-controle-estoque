using ControleEstoque.Domain.Commands.ItemProducts;

namespace ControleEstoque.Domain.Validations.ItemProducts
{
    public class UpdateItemProductCommandValidation : ItemProductValidation<UpdateItemProductCommand>
    {
        public UpdateItemProductCommandValidation()
        {
            ValidateIdItem();
            ValidateIdProduct();
            ValidateItemProductQuantity();
        }
    }
}
