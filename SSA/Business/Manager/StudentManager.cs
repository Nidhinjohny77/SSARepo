﻿
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
                var existingProfile=await this.repository.GetStudentProfileAsync(student.TenantUID);
                if(existingProfile != null)
                {
                    return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(new BusinessException(new ValidationModel("Student profile already exists."))));
                }
                
                var studentEntity = this.mapper.Map<StudentProfile>(student);
                studentEntity.UID = Guid.NewGuid().ToString();
                studentEntity.CreatedBy = loggedInUser;
                studentEntity.CreatedDate = DateTime.Now;
                studentEntity.LastUpdatedBy = loggedInUser;
                studentEntity.LastUpdatedDate = DateTime.Now;
                if(await this.repository.AddStudentAsync(studentEntity))
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        var savedEntity = await this.repository.GetStudentByProfileAsync(studentEntity.UID);
                        var newModel = this.mapper.Map<StudentProfileModel>(savedEntity);
                        return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(newModel));
                    }
                    else
                    {
                        return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(new BusinessException(
                            new ValidationModel("Unable to persist student profile to the database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(new BusinessException(
                        new ValidationModel("Unable to add student profile to the entity collection."))));
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
                var tenant =  this.uow.TenantRepository.GetAllTenants().Where(x => x.UserUID == loggedInUser).FirstOrDefault();
                if(tenant != null)
                {
                    var existingProfile = await this.repository.GetStudentProfileAsync(tenant.UID);
                    if (existingProfile == null)
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(
                            new BusinessException(new ValidationModel("Student profile does not exists."))));
                    }
                    await this.repository.DeleteStudentAsync(existingProfile);
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(true));
                    }
                    else
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(
                            new BusinessException(new ValidationModel("Unable to delete the student profile from database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationModel("Unable to get the student tenant from database."))));
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
                var tenant = this.uow.TenantRepository.GetAllTenants().Where(x => x.UserUID == loggedInUser).FirstOrDefault();
                if (tenant != null)
                {
                    var entity = await this.repository.GetStudentProfileAsync(tenant.UID);
                    if (entity == null)
                    {
                        return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(
                            new BusinessException(new ValidationModel("Student profile not available."))));
                    }
                    else
                    {
                        var model = this.mapper.Map<StudentProfileModel>(entity);
                        return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(model));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(
                            new BusinessException(new ValidationModel("Student tenant profile not available."))));
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
                var existingProfile = await this.repository.GetStudentProfileAsync(student.TenantUID);
                if (existingProfile == null)
                {
                    return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(new BusinessException(new ValidationModel("Student profile doesn't exists."))));
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
                        new BusinessException(new ValidationModel("Unable to save student profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<StudentProfileModel>>(new Result<StudentProfileModel>(ex));
            }
        }
    }
}
