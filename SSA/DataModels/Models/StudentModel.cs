namespace DataModels.Models
{
    [Serializable]
    public class StudentModel
    {
        public string UserUID { get; set; }
        public string ProfileUID { get; set; }
        public string Address { get; set; }
        public string CountryCode { get; set; }
        public string? DOB { get; set; }
        public string PhoneNumber { get; set; }   
        public string StudentID { get; set; }
        public string StudentCode { get; set; }
        public string EnrolledCourseName { get; set; }
        public string UniversityCode { get; set; }
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }

    }
}
