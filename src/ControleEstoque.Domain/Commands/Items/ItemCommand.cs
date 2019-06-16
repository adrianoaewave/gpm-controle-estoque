using ControleEstoque.Domain.Core.Commands;

namespace ControleEstoque.Domain.Commands.Items
{
    public abstract class ItemCommand : Command
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string ERPCode { get; set; }
    }
}
