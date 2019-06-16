using ControleEstoque.Domain.Validations.Customers;

namespace ControleEstoque.Domain.Commands.Customers
{
    public class UpdateCustomerCommand : CustomerCommand
    {
        public UpdateCustomerCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}