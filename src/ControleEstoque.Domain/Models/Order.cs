﻿using ControleEstoque.Domain.Core.Models;
using System;

namespace ControleEstoque.Domain.Models
{
    public class Order : Entity
    {
        public Order(int id, DateTime orderDate, int deliveryDays, int idCustomer, string deliveryDescription, string observation, string erpCode)
        {
            Id = id;
            OrderDate = orderDate;
            DeliveryDays = deliveryDays;
            IdCustomer = IdCustomer;
            DeliveryDescription = deliveryDescription;
            Observation = observation;
            ERPCode = erpCode;
        }

        public Order() { }

        public DateTime OrderDate { get; set; }
        public int DeliveryDays { get; set; }
        public int IdCustomer { get; set; }
        public string DeliveryDescription { get; set; }
        public string Observation { get; set; }
        public string ERPCode { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
