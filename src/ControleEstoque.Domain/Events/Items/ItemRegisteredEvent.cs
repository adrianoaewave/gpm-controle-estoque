using ControleEstoque.Domain.Core.Events;

namespace ControleEstoque.Domain.Events.Items
{
    public class ItemRegisteredEvent : Event
    {
        public ItemRegisteredEvent(int id, string name, int quantidadeEstoque, string erpCode)
        {
            Id = id;
            Name = name;
            QuantidadeEstoque = quantidadeEstoque;
            ERPCode = erpCode;
            AggregateId = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string ERPCode { get; set; }
    }
}
