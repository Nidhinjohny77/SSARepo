

namespace DataAccess.Entities
{
    public class StudentProfile
    {
        public string UID { get; set; }
        public string TenantUID { get; set; }
        public string UniversityStudentID { get; set; }
        public string StudentSecurityCode { get; set; }
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
        public Tenant Tenant { get; set; }
    }
}
