using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalBillingApi.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
