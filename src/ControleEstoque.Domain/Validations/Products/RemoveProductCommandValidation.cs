using ControleEstoque.Domain.Commands.Products;

namespace ControleEstoque.Domain.Validations.Products
{
    public class RemoveProductCommandValidation : ProductValidation<RemoveProductCommand>
    {
        public RemoveProductCommandValidation()
        {
            ValidateId();
        }
    }
}
