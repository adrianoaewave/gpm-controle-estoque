using ControleEstoque.Domain.Interfaces;
using ControleEstoque.Domain.Models;
using ControleEstoque.Infra.Data.Context;

namespace ControleEstoque.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ControleEstoqueContext context) : base(context)
        {

        }
    }
}
