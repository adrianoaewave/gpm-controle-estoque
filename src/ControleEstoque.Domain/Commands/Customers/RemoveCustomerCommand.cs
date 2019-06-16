using System;
using ControleEstoque.Domain.Validations;
using ControleEstoque.Domain.Validations.Customers;

namespace ControleEstoque.Domain.Commands.Customers
{
    public class RemoveCustomerCommand : CustomerCommand
    {
        public RemoveCustomerCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}