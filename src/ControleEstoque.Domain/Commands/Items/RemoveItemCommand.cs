using ControleEstoque.Domain.Validations.Items;

namespace ControleEstoque.Domain.Commands.Items
{
    public class RemoveItemCommand : ItemCommand
    {
        public RemoveItemCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveItemCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
