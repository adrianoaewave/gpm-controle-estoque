using ControleEstoque.Domain.Core.Commands;
using System;

namespace ControleEstoque.Domain.Commands.Orders
{
    public abstract class OrderCommand : Command
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int DeliveryDays { get; set; }
        public int IdCustomer { get; set; }
        public string DeliveryDescription { get; set; }
        public string Observation { get; set; }
        public string ERPCode { get; set; }
    }
}
