using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Student
    {
        public long UID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CountryCode { get; set; }
        public string DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string StudentId { get; set; }
        public string StudentCode { get; set; }
        public string EnrolledCourseName { get; set; }
        public University University { get; set; }
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }

    }
}
