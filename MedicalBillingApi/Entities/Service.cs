using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalBillingApi.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public bool IsActive { get; set; }
        public int DepartmentId { get; set; }
        public decimal Price { get; set; }
        public Department Department { get; set; }
    }
}
