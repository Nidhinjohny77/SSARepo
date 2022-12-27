
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

        public async Task<Result<StudentProfileModel>> CreateStudentProfileAysnc(string loggedInUser, StudentProfileModel student)
        {
            try
            {
                var validationResults=await this.validator.ValidateAsync(loggedInUser, student);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(new BusinessException(validationResults)));
                }
                var existingProfile=await this.repository.GetStudentProfileAsync(loggedInUser);
                if(existingProfile != null)
                {
                    return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(new BusinessException(new ValidationResult("Student profile already exists."))));
                }
                
                var university= this.uow.UniversityRepository.GetAllUniversities().Where(x=>x.UniversityCode == student.UniversityCode).FirstOrDefault();
                if(university != null)
                {
                    var studentEntity = this.mapper.Map<StudentProfile>(student);
                    studentEntity.UID = Guid.NewGuid().ToString();
                    studentEntity.UniversityUID = university.UID;
                    studentEntity.CreatedBy = loggedInUser;
                    studentEntity.CreatedDate = DateTime.Now;
                    studentEntity.LastUpdatedBy = loggedInUser;
                    studentEntity.LastUpdatedDate = DateTime.Now;
                    await this.repository.AddStudentAsync(studentEntity);
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        var savedEntity = await this.repository.GetStudentByProfileAsync(studentEntity.UID);
                        var newModel = this.mapper.Map<StudentProfileModel>(savedEntity);
                        return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(newModel));
                    }
                    else
                    {
                        return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(new BusinessException(
                            new ValidationResult("Unable to add user to the database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(new BusinessException(
                        new ValidationResult("Unable to find the university for the specified university code."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(ex));
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

        public async Task<Result<StudentProfileModel>> GetStudentProfileAsync(string loggedInUser)
        {
            try
            {
                var entity=await this.repository.GetStudentProfileAsync(loggedInUser);
                if(entity == null)
                {
                    return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(
                        new BusinessException(new ValidationResult("Student profile not available."))));
                }
                else
                {
                    var model=this.mapper.Map<StudentProfileModel>(entity);
                    return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(model));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(ex));
            }
        }

        public async Task<Result<StudentProfileModel>> UpdateStudentProfileAsync(string loggedInUser, StudentProfileModel student)
        {
            try
            {
                var validationResults = await this.validator.ValidateAsync(loggedInUser, student);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(new BusinessException(validationResults)));
                }
                var existingProfile = await this.repository.GetStudentProfileAsync(loggedInUser);
                if (existingProfile == null)
                {
                    return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(new BusinessException(new ValidationResult("Student profile doesn't exists."))));
                }
                existingProfile=this.mapper.Map<StudentProfileModel,StudentProfile>(student,existingProfile);
                existingProfile.LastUpdatedBy = loggedInUser;
                existingProfile.LastUpdatedDate = DateTime.Now;  
                if(await this.repository.UpdateStudentAsync(existingProfile) && await this.uow.SaveChangesAsync() > 0)
                {
                    var model=this.mapper.Map<StudentProfileModel>(existingProfile);
                    return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(model));
                }
                else
                {
                    return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(
                        new BusinessException(new ValidationResult("Unable to save student profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(ex));
            }
        }
    }
}
