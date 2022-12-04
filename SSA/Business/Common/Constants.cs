using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Common
{
    public static class RoleConstant
    {
        public static string Admin = "Admin";
        public static string Landlord = "Landlord";
        public static string Student = "Student";
        public static string University = "University";
        public static string Consultant = "Consultant";
    }

    public static class FileConstant
    {
        public static List<string> AcceptedImageFileTypes = new List<string>() { "JPEG" };
    }
}
