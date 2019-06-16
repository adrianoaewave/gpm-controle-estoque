using ControleEstoque.Domain.Interfaces;
using ControleEstoque.Domain.Models;
using ControleEstoque.Infra.Data.Context;

namespace ControleEstoque.Infra.Data.Repository
{
    public class ItemProductRepository : Repository<ItemProduct>, IItemProductRepository
    {
        public ItemProductRepository(ControleEstoqueContext context) : base(context)
        {

        }

        public ItemProduct GetById(int idItem, int idProduct)
        {
            return DbSet.Find(idItem, idProduct);
        }

        public virtual void Remove(int idItem, int idProduct)
        {
            DbSet.Remove(DbSet.Find(idItem, idProduct));
        }
    }
}
