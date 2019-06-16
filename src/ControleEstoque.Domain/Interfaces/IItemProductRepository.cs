using ControleEstoque.Domain.Models;

namespace ControleEstoque.Domain.Interfaces
{
    public interface IItemProductRepository : IRepository<ItemProduct>
    {
        void Remove(int idItem, int idProduct);
        ItemProduct GetById(int idItem, int idProduct);
    }
}
