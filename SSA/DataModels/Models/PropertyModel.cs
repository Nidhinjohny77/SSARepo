using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class PropertyModel
    {
        public string UID { get; set; }
        public string LandlordUID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public int CountryUID { get; set; }
        public float Ratings { get; set; }
        public bool IsActive { get; set; }
    }
}
