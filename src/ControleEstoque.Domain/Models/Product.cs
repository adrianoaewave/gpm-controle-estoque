using ControleEstoque.Domain.Core.Models;

namespace ControleEstoque.Domain.Models
{
    public class Product : Entity
    {
        public Product(int id, string name, string erpCode)
        {
            Id = id;
            Name = name;
            ERPCode = erpCode;
        }

        public Product() { }

        public string Name { get; private set; }
        public string ERPCode { get; private set; }
    }
}
