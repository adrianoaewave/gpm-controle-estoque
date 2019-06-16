using System;
using ControleEstoque.Domain.Core.Commands;

namespace ControleEstoque.Domain.Commands.Customers
{
    public abstract class CustomerCommand : Command
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }
    }
}