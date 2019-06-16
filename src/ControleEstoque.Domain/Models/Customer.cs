using System;
using ControleEstoque.Domain.Core.Models;

namespace ControleEstoque.Domain.Models
{
    public class Customer : Entity
    {
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Empty constructor for EF
        protected Customer() { }

        public string Name { get; private set; }
    }
}