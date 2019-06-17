using ControleEstoque.Domain.Validations.Orders;

namespace ControleEstoque.Domain.Commands.Orders
{
    public class RemoveOrderCommand : OrderCommand
    {
        public RemoveOrderCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
