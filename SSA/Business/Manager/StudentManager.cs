
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

        public async Task<Result<StudentModel>> CreateStudentProfileAysnc(string userUID, StudentModel student)
        {
            try
            {
                student.UserUID=userUID;
                var validationResults=await this.validator.ValidateAsync(userUID, student);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(new BusinessException(validationResults)));
                }
                var existingProfile=await this.repository.GetStudentProfileAsync(userUID);
                if(existingProfile != null)
                {
                    return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(new BusinessException(new ValidationResult("Student profile already exists."))));
                }
                var studentEntity=this.mapper.Map<Student>(student);
                studentEntity.ProfileUID=Guid.NewGuid().ToString();
                studentEntity.UserUID=student.UserUID;
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

        public async Task<Result<bool>> DeleteStudentProfileAsync(string userUID)
        {
            try
            {
                var existingProfile = await this.repository.GetStudentProfileAsync(userUID);
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

        public async Task<Result<StudentModel>> GetStudentProfileAsync(string userUID)
        {
            try
            {
                var entity=await this.repository.GetStudentProfileAsync(userUID);
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

        public async Task<Result<StudentModel>> UpdateStudentProfileAsync(string userUID, StudentModel student)
        {
            try
            {
                var validationResults = await this.validator.ValidateAsync(userUID, student);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(new BusinessException(validationResults)));
                }
                var existingProfile = await this.repository.GetStudentProfileAsync(userUID);
                if (existingProfile == null)
                {
                    return await Task.FromResult<Result<StudentModel>>(new Result<StudentModel>(new BusinessException(new ValidationResult("Student profile doesn't exists."))));
                }
                var updatedEntity=this.mapper.Map<Student>(student);
                updatedEntity.ProfileUID=existingProfile.ProfileUID;
                updatedEntity.UserUID= existingProfile.UserUID;
                await this.repository.UpdateStudentAsync(updatedEntity);    
                if(await this.uow.SaveChangesAsync() > 0)
                {
                    var model=this.mapper.Map<StudentModel>(updatedEntity);
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
