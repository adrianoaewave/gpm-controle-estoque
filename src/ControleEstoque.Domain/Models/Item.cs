using ControleEstoque.Domain.Core.Models;

namespace ControleEstoque.Domain.Models
{
    public class Item : Entity
    {
        public Item(int id, string name, int quantidadeEstoque, string erpCode)
        {
            Id = id;
            Name = name;
            QuantidadeEstoque = quantidadeEstoque;
            ERPCode = erpCode;
        }

        public Item() { }

        public string Name { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string ERPCode { get; set; }
    }
}
