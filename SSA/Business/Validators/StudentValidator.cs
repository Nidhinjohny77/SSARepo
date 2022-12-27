

namespace Business.Validators
{
    public class StudentValidator : ValidatorBase, IStudentValidator
    {
        private readonly IStudentRepository repo;

        public StudentValidator(IUnitOfWork uow):base(uow)
        {
            this.repo = uow.StudentRepository;
        }

        protected string GetUserUID(string tenantUID)
        {
            var tenant = this.uow.TenantRepository.GetTenantAsync(tenantUID).Result;
           
            return tenant == null ? null : tenant.UserUID;
        }

        public async Task<List<ValidationResult>> ValidateAsync(string loggedInUser, StudentProfileModel student)
        {
            var validationResults=new List<ValidationResult>();
            var modelSpecificUserUID = GetUserUID(student.TenantUID);
            if ( GetRole(modelSpecificUserUID)!=RoleConstant.Admin && modelSpecificUserUID != loggedInUser)
            {
                validationResults.Add(new ValidationResult("The current loggedIn user doesn't have permission to edit profile of another user."));
            }
            if(string.IsNullOrEmpty(student.UniversityStudentID))
            {
                validationResults.Add(new ValidationResult("UniversityStudentID is a mandatory field."));
            }
            if (string.IsNullOrEmpty(student.StudentSecurityCode))
            {
                validationResults.Add(new ValidationResult("StudentSecurityCode is a mandatory field."));
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

            return await Task.FromResult<List<ValidationResult>>(validationResults);
        }
    }
}
