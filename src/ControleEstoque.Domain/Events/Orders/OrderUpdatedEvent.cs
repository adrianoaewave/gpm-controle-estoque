using ControleEstoque.Domain.Core.Events;
using System;

namespace ControleEstoque.Domain.Events.Orders
{
    public class OrderUpdatedEvent : Event
    {
        public OrderUpdatedEvent(int id, DateTime orderDate, int deliveryDays, int idCustomer, string deliveryDescription, 
                                 string observation, string erpCode)
        {
            Id = id;
            OrderDate = orderDate;
            DeliveryDays = deliveryDays;
            IdCustomer = IdCustomer;
            DeliveryDescription = deliveryDescription;
            Observation = observation;
            ERPCode = erpCode;
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int DeliveryDays { get; set; }
        public int IdCustomer { get; set; }
        public string DeliveryDescription { get; set; }
        public string Observation { get; set; }
        public string ERPCode { get; set; }
    }
}
