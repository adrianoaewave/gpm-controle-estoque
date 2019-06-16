using System;
using ControleEstoque.Domain.Core.Events;

namespace ControleEstoque.Domain.Events.Customers
{
    public class CustomerRegisteredEvent : Event
    {
        public CustomerRegisteredEvent(int id, string name)
        {
            Id = id;
            Name = name;
            AggregateId = id;
        }
        public int Id { get; set; }

        public string Name { get; private set; }
    }
}