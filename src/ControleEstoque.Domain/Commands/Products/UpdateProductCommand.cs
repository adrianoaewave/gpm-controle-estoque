using ControleEstoque.Domain.Validations.Products;

namespace ControleEstoque.Domain.Commands.Products
{
    public class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand(int id, string name, string erpCode)
        {
            Id = id;
            Name = name;
            ERPCode = erpCode;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
