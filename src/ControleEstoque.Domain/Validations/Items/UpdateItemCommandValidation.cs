using ControleEstoque.Domain.Commands.Items;

namespace ControleEstoque.Domain.Validations.Items
{
    public class UpdateItemCommandValidation : ItemValidation<UpdateItemCommand>
    {
        public UpdateItemCommandValidation()
        {
            ValidateId();
            ValidateERPCode();
            ValidateName();
            ValidateQuantidadeEstoque();
        }
    }
}
