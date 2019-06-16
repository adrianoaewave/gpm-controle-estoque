using ControleEstoque.Domain.Core.Events;

namespace ControleEstoque.Domain.Events.Products
{
    public class ProductRemovedEvent : Event
    {
        public ProductRemovedEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public int Id { get; set; }
    }
}
