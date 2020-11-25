using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalBillingApi.Entities
{
    public class Receipt
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentMode { get; set; }
        public string CashierId { get; set; }
        public AppUser Cashier { get; set; }
    }
}
