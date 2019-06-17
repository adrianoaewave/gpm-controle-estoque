using ControleEstoque.Domain.Validations.Orders;
using System;

namespace ControleEstoque.Domain.Commands.Orders
{
    public class RegisterNewOrderCommand : OrderCommand
    {
        public RegisterNewOrderCommand(DateTime orderDate, int deliveryDays, int idCustomer, string deliveryDescription, 
                                       string observation, string erpCode)
        {
            OrderDate = orderDate;
            DeliveryDays = deliveryDays;
            IdCustomer = IdCustomer;
            DeliveryDescription = deliveryDescription;
            Observation = observation;
            ERPCode = erpCode;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
