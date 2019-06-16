using ControleEstoque.Domain.Interfaces;
using ControleEstoque.Domain.Models;
using ControleEstoque.Infra.Data.Context;

namespace ControleEstoque.Infra.Data.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ControleEstoqueContext context) : base(context)
        {

        }
    }
}
