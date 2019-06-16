using ControleEstoque.Domain.Validations.Products;

namespace ControleEstoque.Domain.Commands.Products
{
    public class RemoveProductCommand : ProductCommand
    {
        public RemoveProductCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
