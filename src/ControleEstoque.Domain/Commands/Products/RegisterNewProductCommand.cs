using ControleEstoque.Domain.Validations.Products;

namespace ControleEstoque.Domain.Commands.Products
{
    public class RegisterNewProductCommand : ProductCommand
    {
        public RegisterNewProductCommand(string name, string erpCode)
        {
            Name = name;
            ERPCode = erpCode;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
