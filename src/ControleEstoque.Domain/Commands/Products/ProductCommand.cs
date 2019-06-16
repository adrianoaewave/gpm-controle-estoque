using ControleEstoque.Domain.Core.Commands;

namespace ControleEstoque.Domain.Commands.Products
{
    public abstract class ProductCommand : Command
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string ERPCode { get; protected set; }
    }
}
