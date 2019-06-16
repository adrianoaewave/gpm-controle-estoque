using ControleEstoque.Domain.Core.Events;

namespace ControleEstoque.Domain.Events.Items
{
    public class ItemRemovedEvent : Event
    {
        public ItemRemovedEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public int Id { get; set; }
    }
}
