namespace ControleEstoque.Domain.Models
{
    public class ItemProduct
    {
        public ItemProduct(int idItem, int idProduct, int itemProductQuantity)
        {
            IdItem = idItem;
            IdProduct = idProduct;
            ItemProductQuantity = itemProductQuantity;
        }

        public ItemProduct() { }

        public int IdItem { get; set; }
        public int IdProduct { get; set; }
        public int ItemProductQuantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Item Item { get; set; }
    }
}
