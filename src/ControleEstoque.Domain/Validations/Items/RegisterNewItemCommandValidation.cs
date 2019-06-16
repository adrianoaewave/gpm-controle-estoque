using ControleEstoque.Domain.Commands.Items;

namespace ControleEstoque.Domain.Validations.Items
{
    public class RegisterNewItemCommandValidation : ItemValidation<RegisterNewItemCommand>
    {
        public RegisterNewItemCommandValidation()
        {
            ValidateERPCode();
            ValidateName();
            ValidateQuantidadeEstoque();
        }
    }
}
