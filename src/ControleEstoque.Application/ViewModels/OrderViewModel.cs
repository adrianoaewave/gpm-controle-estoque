using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Application.ViewModels
{
    public class OrderViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Order Date is Required")]
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "The Delivery Days is Required")]
        [DisplayName("Delivery Days")]
        public int DeliveryDays { get; set; }

        [Required(ErrorMessage = "The Customer is Required")]
        [DisplayName("Customer")]
        public int IdCustomer { get; set; }

        [Required(ErrorMessage = "The Delivery Description is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Delivery Description")]
        public string DeliveryDescription { get; set; }

        [Required(ErrorMessage = "The Observation is Required")]
        [MinLength(2)]
        [MaxLength(500)]
        [DisplayName("Observation")]
        public string Observation { get; set; }

        [Required(ErrorMessage = "The ERP Code is Required")]
        [MinLength(2)]
        [MaxLength(20)]
        [DisplayName("ERP Code")]
        public string ERPCode { get; set; }
    }
}
