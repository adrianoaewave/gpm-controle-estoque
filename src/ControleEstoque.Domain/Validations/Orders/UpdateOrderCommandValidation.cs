using ControleEstoque.Domain.Commands.Orders;

namespace ControleEstoque.Domain.Validations.Orders
{
    public class UpdateOrderCommandValidation : OrderValidation<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidation()
        {
            ValidateDeliveryDays();
            ValidateDeliveryDescription();
            ValidateERPCode();
            ValidateId();
            ValidateIdCustomer();
            ValidateObservation();
            ValidateOrderDate();
        }
    }
}
