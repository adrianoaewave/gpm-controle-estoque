using ControleEstoque.Domain.Commands.Products;
using FluentValidation;

namespace ControleEstoque.Domain.Validations.Products
{
    public class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
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

        protected void ValidateERPCode()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the ERP Code")
                .Length(2, 20).WithMessage("The ERP Code must have between 2 and 20 characters");
        }
    }
}
