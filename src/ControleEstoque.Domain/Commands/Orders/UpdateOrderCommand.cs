using ControleEstoque.Domain.Validations.Orders;
using System;

namespace ControleEstoque.Domain.Commands.Orders
{
    public class UpdateOrderCommand : OrderCommand
    {
        public UpdateOrderCommand(int id, DateTime orderDate, int deliveryDays, int idCustomer, string deliveryDescription, 
                                  string observation, string erpCode)
        {
            Id = id;
            OrderDate = orderDate;
            DeliveryDays = deliveryDays;
            IdCustomer = IdCustomer;
            DeliveryDescription = deliveryDescription;
            Observation = observation;
            ERPCode = erpCode;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
