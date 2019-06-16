using ControleEstoque.Domain.Commands.Products;

namespace ControleEstoque.Domain.Validations.Products
{
    public class UpdateProductCommandValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProductCommandValidation()
        {
            ValidateId();
            ValidateERPCode();
            ValidateName();
        }
    }
}
