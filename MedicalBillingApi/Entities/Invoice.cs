using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalBillingApi.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string BillerId { get; set; } 
        public bool IsActive { get; set; }
        public bool HasPaid { get; set; }
        public string Number { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime CustomerDateOfBirth { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public AppUser Biller { get; set; }

        public Customer Customer { get; set; }

        private readonly List<InvoiceItem> _invoiceItems = new List<InvoiceItem>();
        public IReadOnlyCollection<InvoiceItem> InvoiceItems => _invoiceItems.AsReadOnly();

        public void AddInvoiceItem(InvoiceItem item)
        {
            _invoiceItems.Add(item);
        }
    }
}
