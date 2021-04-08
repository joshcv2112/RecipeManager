using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// TEMPORARY FILE JUST FOR EXAMPLE, DELETE LATER

namespace RecipeManager.Data
{
    public class JobApplication
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public int SalaryExpectations { get; set; }
        public bool DoesOpenSource { get; set; }
        public DateTime Availability { get; set; }
    }
}
