using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalBillingApi.DTO
{
    public class InvoiceRequestDTO
    {
        public int? CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime CustomerDateOfBirth { get; set; }
        public bool SaveCustomer { get; set; }
        public string Prefix { get; set; }
        public List<InvoiceItemDTO> Services { get; set; }
    }


    public class InvoiceItemDTO
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
