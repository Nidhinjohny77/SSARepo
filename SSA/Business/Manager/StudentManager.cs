
namespace Business.Manager
{
    public class StudentManager : IStudentManager
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IStudentValidator validator;
        private readonly IStudentRepository repository;

        public StudentManager(IUnitOfWork uow,IMapper mapper,IStudentValidator validator)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.validator = validator;
            this.repository = this.uow.StudentRepository;
        }

        public async Task<Result<StudentModel>> CreateStudentProfileAysnc(string loggedInUser, StudentModel student)
        {
            try
            {
                var validationResults=await this.validator.ValidateAsync(loggedInUser, student);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(new BusinessException(validationResults)));
                }
                var existingProfile=await this.repository.GetStudentProfileAsync(loggedInUser);
                if(existingProfile != null)
                {
                    return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(new BusinessException(new ValidationResult("Student profile already exists."))));
                }
                var studentEntity=this.mapper.Map<Student>(student);
                studentEntity.ProfileUID=Guid.NewGuid().ToString();
                studentEntity.CreatedBy=loggedInUser;
                studentEntity.CreatedDate=DateTime.Now;
                studentEntity.LastUpdatedBy=loggedInUser;
                studentEntity.LastUpdatedDate=DateTime.Now;
                await this.repository.AddStudentAsync(studentEntity);
                if( await this.uow.SaveChangesAsync() > 0)
                {
                    var savedEntity=await this.repository.GetStudentByProfileAsync(studentEntity.ProfileUID);
                    var newModel=this.mapper.Map<StudentModel>(savedEntity);
                    return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(newModel));
                }
                else
                {
                    return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(new BusinessException(
                        new ValidationResult("Unable to add user to the database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(ex));
            }
        }

        public async Task<Result<bool>> DeleteStudentProfileAsync(string loggedInUser)
        {
            try
            {
                var existingProfile = await this.repository.GetStudentProfileAsync(loggedInUser);
                if (existingProfile == null)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationResult("Student profile does not exists."))));
                }
                await this.repository.DeleteStudentAsync(existingProfile);
                if(await this.uow.SaveChangesAsync() > 0)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(true));
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationResult("Unable to delete the student profile from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<StudentModel>> GetStudentProfileAsync(string loggedInUser)
        {
            try
            {
                var entity=await this.repository.GetStudentProfileAsync(loggedInUser);
                if(entity == null)
                {
                    return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(
                        new BusinessException(new ValidationResult("Student profile not available."))));
                }
                else
                {
                    var model=this.mapper.Map<StudentModel>(entity);
                    return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(model));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(ex));
            }
        }

        public async Task<Result<StudentModel>> UpdateStudentProfileAsync(string loggedInUser, StudentModel student)
        {
            try
            {
                var validationResults = await this.validator.ValidateAsync(loggedInUser, student);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(new BusinessException(validationResults)));
                }
                var existingProfile = await this.repository.GetStudentProfileAsync(loggedInUser);
                if (existingProfile == null)
                {
                    return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(new BusinessException(new ValidationResult("Student profile doesn't exists."))));
                }
                existingProfile=this.mapper.Map<StudentModel,Student>(student,existingProfile);
                existingProfile.LastUpdatedBy = loggedInUser;
                existingProfile.LastUpdatedDate = DateTime.Now;  
                if(await this.repository.UpdateStudentAsync(existingProfile) && await this.uow.SaveChangesAsync() > 0)
                {
                    var model=this.mapper.Map<StudentModel>(existingProfile);
                    return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(model));
                }
                else
                {
                    return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(
                        new BusinessException(new ValidationResult("Unable to save student profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(ex));
            }
        }
    }
}
