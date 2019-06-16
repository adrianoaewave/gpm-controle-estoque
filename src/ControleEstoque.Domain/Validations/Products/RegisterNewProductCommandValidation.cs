using ControleEstoque.Domain.Commands.Products;

namespace ControleEstoque.Domain.Validations.Products
{
    public class RegisterNewProductCommandValidation : ProductValidation<RegisterNewProductCommand>
    {
        public RegisterNewProductCommandValidation()
        {
            ValidateName();
            ValidateERPCode();
        }
    }
}
