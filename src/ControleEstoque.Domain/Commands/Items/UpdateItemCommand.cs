using ControleEstoque.Domain.Validations.Items;

namespace ControleEstoque.Domain.Commands.Items
{
    public class UpdateItemCommand : ItemCommand
    {
        public UpdateItemCommand(int id, string name, int quantidadeEstoque, string erpCode)
        {
            Id = id;
            Name = name;
            QuantidadeEstoque = quantidadeEstoque;
            ERPCode = erpCode;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateItemCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
