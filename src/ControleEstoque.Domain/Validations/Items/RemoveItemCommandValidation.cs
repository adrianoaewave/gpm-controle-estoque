using ControleEstoque.Domain.Commands.Items;

namespace ControleEstoque.Domain.Validations.Items
{
    public class RemoveItemCommandValidation : ItemValidation<RemoveItemCommand>
    {
        public RemoveItemCommandValidation()
        {
            ValidateId();
        }
    }
}
