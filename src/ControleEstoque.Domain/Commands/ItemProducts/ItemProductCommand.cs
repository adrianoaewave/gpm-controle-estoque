using ControleEstoque.Domain.Core.Commands;

namespace ControleEstoque.Domain.Commands.ItemProducts
{
    public abstract class ItemProductCommand : Command
    {
        public int IdProduct { get; set; }
        public int IdItem { get; set; }
        public int ItemProductQuantity { get; set; }
    }
}
