

namespace Business.Validators
{
    public class StudentValidator : IStudentValidator
    {
        public async Task<List<ValidationResult>> ValidateAsync(string loggedInUser, StudentModel student)
        {
            var validationResults=new List<ValidationResult>();
            if (student.UserUID != loggedInUser)
            {
                validationResults.Add(new ValidationResult("There is a mismatch between logged in user and user specified in the model."));
            }
            if(string.IsNullOrEmpty(student.StudentID))
            {
                validationResults.Add(new ValidationResult("StudentID is a mandatory field."));
            }
            if (string.IsNullOrEmpty(student.StudentCode))
            {
                validationResults.Add(new ValidationResult("StudentCode is a mandatory field."));
            }
            if (student.CourseStartDate==null)
            {
                validationResults.Add(new ValidationResult("Course start date is a mandatory field."));
            }
            if (student.CourseEndDate == null)
            {
                validationResults.Add(new ValidationResult("Course end date is a mandatory field."));
            }
            DateOnly startDate;
            DateOnly endDate;
            bool isValidStartDate = DateOnly.TryParse(student.CourseStartDate, out startDate);
            bool isValidEndDate = DateOnly.TryParse(student.CourseEndDate, out endDate);
            if (!isValidStartDate)
            {
                validationResults.Add(new ValidationResult("Course start date is not in proper date format (dd/mm/yyyy)."));
            }            
            if (!isValidEndDate)
            {
                validationResults.Add(new ValidationResult("Course end date is not in proper date format (dd/mm/yyyy)."));
            }
            if ((isValidStartDate && isValidEndDate) && (startDate > endDate))
            {
                validationResults.Add(new ValidationResult("Course start date and end date should be valid."));
            }
            if (string.IsNullOrEmpty(student.Address))
            {
                validationResults.Add(new ValidationResult("Address is a mandatory field."));
            }
            if (string.IsNullOrEmpty(student.CountryCode))
            {
                validationResults.Add(new ValidationResult("CountryCode is a mandatory field."));
            }
            if (string.IsNullOrEmpty(student.EnrolledCourseName))
            {
                validationResults.Add(new ValidationResult("Course Name is a mandatory field."));
            }
            if (string.IsNullOrEmpty(student.PhoneNumber))
            {
                validationResults.Add(new ValidationResult("PhoneNumber is a mandatory field."));
            }
            if (string.IsNullOrEmpty(student.DOB))
            {
                validationResults.Add(new ValidationResult("Date of birth is a mandatory field."));
            }
            return await Task.FromResult<List<ValidationResult>>(validationResults);
        }
    }
}
