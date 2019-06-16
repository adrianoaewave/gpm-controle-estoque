using ControleEstoque.Domain.Commands;
using ControleEstoque.Domain.Commands.Customers;

namespace ControleEstoque.Domain.Validations.Customers
{
    public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
    {
        public RegisterNewCustomerCommandValidation()
        {
            ValidateName();
        }
    }
}