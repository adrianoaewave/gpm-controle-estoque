using ControleEstoque.Domain.Interfaces;
using ControleEstoque.Domain.Models;
using ControleEstoque.Infra.Data.Context;

namespace ControleEstoque.Infra.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ControleEstoqueContext context) : base(context)
        {

        }
    }
}
