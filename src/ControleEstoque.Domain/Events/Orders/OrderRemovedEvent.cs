using ControleEstoque.Domain.Core.Events;

namespace ControleEstoque.Domain.Events.Orders
{
    public class OrderRemovedEvent : Event
    {
        public OrderRemovedEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public int Id { get; set; }
    }
}
