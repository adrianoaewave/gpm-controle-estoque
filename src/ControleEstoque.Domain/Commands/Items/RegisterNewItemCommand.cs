using ControleEstoque.Domain.Validations.Items;

namespace ControleEstoque.Domain.Commands.Items
{
    public class RegisterNewItemCommand : ItemCommand
    {
        public RegisterNewItemCommand(string name, int quantidadeEstoque, string erpCode)
        {
            Name = name;
            QuantidadeEstoque = quantidadeEstoque;
            ERPCode = erpCode;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewItemCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
