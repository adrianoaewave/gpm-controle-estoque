using System.Linq;
using ControleEstoque.Domain.Interfaces;
using ControleEstoque.Domain.Models;
using ControleEstoque.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ControleEstoqueContext context)
            : base(context)
        {

        }
    }
}
