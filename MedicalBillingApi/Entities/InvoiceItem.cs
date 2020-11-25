using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalBillingApi.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public bool HasPaid { get; set; }
        public decimal Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public bool IsDeleted { get; set; }
        public int ItemId { get; set; }
        public int? ReceiptId { get; set; }
        public Invoice Invoice { get; set; }
        public Service Item { get; set; }
        public Receipt Receipt { get; set; }
    }
}
