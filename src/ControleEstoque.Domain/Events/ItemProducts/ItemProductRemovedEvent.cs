using ControleEstoque.Domain.Core.Events;

namespace ControleEstoque.Domain.Events.ItemProducts
{
    public class ItemProductRemovedEvent : Event
    {
        public ItemProductRemovedEvent(int idItem, int idProduct)
        {
            IdItem = idItem;
            IdProduct = idProduct;
        }

        public int IdItem { get; set; }
        public int IdProduct { get; set; }
    }
}
