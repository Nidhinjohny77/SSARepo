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
        public string LandlordProfileUID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Ratings { get; set; }
        public bool IsActive { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public List<PropertyListingModel> Listings { get; set; }
        public List<PropertyReviewModel> Reviews { get; set; }
    }
}
