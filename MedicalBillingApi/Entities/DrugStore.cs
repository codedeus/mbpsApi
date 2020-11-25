using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalBillingApi.Entities
{
    public class DrugStore
    {
        public int Id { get; set; }
        public int DrugId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
        public string Activity { get; set; }
        public string PharmacistId { get; set; }
        public string ActivityReference { get; set; }

        public Service Drug { get; set; }
        public AppUser Pharmacist { get; set; }
    }
}
