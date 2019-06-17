using ControleEstoque.Domain.Commands.Orders;

namespace ControleEstoque.Domain.Validations.Orders
{
    public class RegisterNewOrderCommandValidation : OrderValidation<RegisterNewOrderCommand>
    {
        public RegisterNewOrderCommandValidation()
        {
            ValidateDeliveryDays();
            ValidateDeliveryDescription();
            ValidateERPCode();
            ValidateIdCustomer();
            ValidateObservation();
            ValidateOrderDate();
        }
    }
}
