using ControleEstoque.Domain.Commands.Items;
using FluentValidation;

namespace ControleEstoque.Domain.Validations.Items
{
    public class ItemValidation<T> : AbstractValidator<T> where T : ItemCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 100).WithMessage("The Name must have between 2 and 100 characters");
        }

        protected void ValidateQuantidadeEstoque()
        {
            RuleFor(c => c.QuantidadeEstoque)
                .GreaterThanOrEqualTo(0).WithMessage("The Quantidade de Estoque must be more greater or Equal zero");
        }

        protected void ValidateERPCode()
        {
            RuleFor(c => c.ERPCode)
                .Length(2, 20).WithMessage("The ERP Code must have between 2 and 20 characters");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .GreaterThanOrEqualTo(0);
        }
    }
}
