using System;
using ControleEstoque.Domain.Core.Events;

namespace ControleEstoque.Domain.Events.Customers
{
    public class CustomerRemovedEvent : Event
    {
        public CustomerRemovedEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public int Id { get; set; }
    }
}