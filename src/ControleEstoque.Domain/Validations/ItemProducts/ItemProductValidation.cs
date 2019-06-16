using ControleEstoque.Domain.Commands.ItemProducts;
using FluentValidation;

namespace ControleEstoque.Domain.Validations.ItemProducts
{
    public class ItemProductValidation<T> : AbstractValidator<T> where T : ItemProductCommand
    {
        protected void ValidateItemProductQuantity()
        {
            RuleFor(c => c.ItemProductQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("The Item Product Quantoty must be more greater or Equal zero");
        }

        protected void ValidateIdItem()
        {
            RuleFor(c => c.IdItem)
                .GreaterThanOrEqualTo(0).WithMessage("The Id Item must be more greater than or Equal zero");
        }

        protected void ValidateIdProduct()
        {
            RuleFor(c => c.IdProduct)
                .GreaterThanOrEqualTo(0).WithMessage("The Id Product must be more greater than or Equal zero");
        }
    }
}
