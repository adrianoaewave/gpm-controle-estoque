using ControleEstoque.Domain.Interfaces;
using ControleEstoque.Infra.Data.Context;
using System;

namespace ControleEstoque.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ControleEstoqueContext _context;

        public UnitOfWork(ControleEstoqueContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;           
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
