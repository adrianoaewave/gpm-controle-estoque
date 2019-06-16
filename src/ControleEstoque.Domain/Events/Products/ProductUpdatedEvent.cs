using ControleEstoque.Domain.Core.Events;

namespace ControleEstoque.Domain.Events.Products
{
    public class ProductUpdatedEvent : Event
    {
        public ProductUpdatedEvent(int id, string name, string erpCode)
        {
            Id = id;
            Name = name;
            ERPCode = erpCode;
            AggregateId = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPCode { get; set; }
    }
}
