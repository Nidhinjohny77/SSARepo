namespace DataModels.Models
{
    [Serializable]
    public class StudentProfileModel
    {
        public string UID { get; set; }
        public string TenantUID { get; set; }
        public int UniversityUID { get; set; }
        public string UniversityStudentID { get; set; }
        public string StudentSecurityCode { get; set; }
        public string EnrolledCourseName { get; set; }
        public string CourseStartDate { get; set; }
        public string CourseEndDate { get; set; }
        public bool IsActive { get; set; }

    }
}
