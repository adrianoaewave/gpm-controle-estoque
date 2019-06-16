using System;
using ControleEstoque.Domain.Commands;
using ControleEstoque.Domain.Commands.Customers;
using FluentValidation;

namespace ControleEstoque.Domain.Validations.Customers
{
    public abstract class CustomerValidation<T> : AbstractValidator<T> where T : CustomerCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 100).WithMessage("The Name must have between 2 and 100 characters");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .GreaterThanOrEqualTo(0);
        }
    }
}