﻿using ControleEstoque.Domain.Core.Events;

namespace ControleEstoque.Domain.Events.ItemProducts
{
    public class ItemProductUpdatedEvent : Event
    {
        public ItemProductUpdatedEvent(int idItem, int idProduct, int itemProductQuantity)
        {
            IdItem = idItem;
            IdProduct = idProduct;
            ItemProductQuantity = itemProductQuantity;
        }

        public int IdItem { get; set; }
        public int IdProduct { get; set; }
        public int ItemProductQuantity { get; set; }
    }
}
