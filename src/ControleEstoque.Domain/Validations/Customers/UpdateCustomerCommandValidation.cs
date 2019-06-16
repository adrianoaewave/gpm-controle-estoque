using ControleEstoque.Domain.Commands;
using ControleEstoque.Domain.Commands.Customers;

namespace ControleEstoque.Domain.Validations.Customers
{
    public class UpdateCustomerCommandValidation : CustomerValidation<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}