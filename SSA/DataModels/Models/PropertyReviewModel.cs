
namespace DataModels.Models
{
    public class PropertyReviewModel
    {
        public string UID { get; set; }
        public string PropertyUID { get; set; }
        public string ReviewDescription { get; set; }
        public string ReviewerUID { get; set; }
        public int ReviewRating { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
