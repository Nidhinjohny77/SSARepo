
namespace DataAccess.Entities
{
    public class Student
    {
        public string UserUID { get; set; }
        public string ProfileUID { get; set; }
        public string Address { get; set; }
        public string CountryCode { get; set; }
        public string ContinentCode { get; set; }
        public string DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string StudentId { get; set; }
        public string StudentCode { get; set; }
        public string EnrolledCourseName { get; set; }
        public int UniversityUID { get; set; }
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public University University { get; set; }
        public User User { get; set; }

    }
}
