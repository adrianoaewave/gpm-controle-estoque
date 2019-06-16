using ControleEstoque.Domain.Commands.Customers;

namespace ControleEstoque.Domain.Validations.Customers
{
    public class RemoveCustomerCommandValidation : CustomerValidation<RemoveCustomerCommand>
    {
        public RemoveCustomerCommandValidation()
        {
            ValidateId();
        }
    }
}