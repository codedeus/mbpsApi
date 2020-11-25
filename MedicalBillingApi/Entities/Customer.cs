using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalBillingApi.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }
        public string CreatedById { get; set; }
        public bool IsActive { get; set; }
        public string Number { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ResidentialAddress { get; set; }
        public string MaritalState { get; set; }
        public AppUser CreatedBy { get; set; }

        public virtual List<Invoice> Invoices { get; set; }
    }
}
