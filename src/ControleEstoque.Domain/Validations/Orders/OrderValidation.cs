using ControleEstoque.Domain.Commands.Orders;
using FluentValidation;
using System;

namespace ControleEstoque.Domain.Validations.Orders
{
    public class OrderValidation<T> : AbstractValidator<T> where T : OrderCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .GreaterThanOrEqualTo(0);
        }

        protected void ValidateOrderDate()
        {
            RuleFor(c => c.OrderDate)
                .GreaterThan(DateTime.Now).WithMessage("The date must be greater or equal today");
        }

        protected void ValidateDeliveryDays()
        {
            RuleFor(c => c.DeliveryDays)
                .GreaterThanOrEqualTo(0).WithMessage("The delivery days must be greater zero");
        }

        protected void ValidateIdCustomer()
        {
            RuleFor(c => c.IdCustomer)
                .GreaterThanOrEqualTo(0).WithMessage("The Customer is required") ;
        }

        protected void ValidateDeliveryDescription()
        {
            RuleFor(c => c.DeliveryDescription)
                .NotEmpty().WithMessage("Please ensure you have entered the Delivery Description")
                .Length(2, 100).WithMessage("The Delivery Description must have between 2 and 100 characters");
        }

        protected void ValidateObservation()
        {
            RuleFor(c => c.Observation)
                .NotEmpty().WithMessage("Please ensure you have entered the Observation")
                .Length(2, 500).WithMessage("The Observation must have between 2 and 500 characters");
        }

        protected void ValidateERPCode()
        {
            RuleFor(c => c.ERPCode)
                .NotEmpty().WithMessage("Please ensure you have entered the ERP Code")
                .Length(2, 20).WithMessage("The ERP Code must have between 2 and 20 characters");
        }
    }
}
