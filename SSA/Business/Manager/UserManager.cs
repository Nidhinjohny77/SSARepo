
namespace Business.Manager
{
    public class UserManager : IUserManager
    {

        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IUserValidator validator;
        private readonly IUserRepository repository;

        public UserManager(IUnitOfWork uow, IMapper mapper,IUserValidator validator)
        {
            this.uow = uow;
            this.repository = this.uow.UserRepository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<Result<UserModel>> CreateUserAsync(UserModel user)
        {
            try
            {
                user.UID=Guid.NewGuid().ToString();
                var results = await this.validator.ValidateAsync(user.UID, user);
                if (results != null && results.Any())
                {
                    return await Task.FromResult<Result<UserModel>>(new Result<UserModel>(new BusinessException(results)));
                }
                var existingUser=await this.repository.GetUserAsync(user.UserName);
                if (existingUser != null)
                {
                    return await Task.FromResult<Result<UserModel>>(new Result<UserModel>(new BusinessException(new ValidationResult("Given user name exists."))));
                }
                var userEntity=this.mapper.Map<User>(user);
                if(userEntity != null)
                {                 
                    var role = this.uow.RolesRepository.GetAllRoles().Where(x => x.Name == user.Role.Name).FirstOrDefault();
                    if(role != null)
                    {
                        userEntity.RoleUID= role.UID;
                        user.Role.UID= role.UID;
                        userEntity.UserType = GetUserType(user.Role);
                        userEntity.CreatedBy = userEntity.UID;
                        userEntity.CreatedDate = DateTime.Now;
                        userEntity.LastUpdatedBy = userEntity.UID;
                        userEntity.LastUpdatedDate = DateTime.Now;
                        var savedUser = await this.repository.CreateUserAsync(userEntity);
                        if (await this.uow.SaveChangesAsync() > 0)
                        {
                            var result = this.mapper.Map<UserModel>(savedUser);
                            return await Task.FromResult<Result<UserModel>>(new Result<UserModel>(result));
                        }
                        else
                        {
                            return await Task.FromResult<Result<UserModel>>(new Result<UserModel>(
                                new BusinessException(new ValidationResult("Unable to save new user."))));
                        }
                    }
                    else
                    {
                        return await Task.FromResult<Result<UserModel>>(new Result<UserModel>(
                            new BusinessException(new ValidationResult("Unable to map given role as its not available."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<UserModel>>(new Result<UserModel>(
                        new BusinessException(new ValidationResult("Unable to map new user."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<UserModel>>(new Result<UserModel>(ex));
            }
        }

        public async Task<Result<bool>> DeleteUserAsync(string loggedInUser, UserModel user)
        {
            try
            {
                var results = await this.validator.ValidateAsync(loggedInUser, user);
                if (results != null && results.Any())
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(results)));
                }
                var entity = await this.repository.GetUserAsync(user.UserName);
                if (entity == null)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationResult("User doesn't exists"))));
                }
                else
                {
                    var flag = await this.repository.DeleteUserAsync(entity);
                    if(await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(flag));
                    }
                    else
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationResult("Unable to save to database."))));
                    }
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<UserModel>> GetUserAsync(string userUID)
        {
            try
            {
                var entity = await this.repository.GetUserByUIDAsync(userUID);
                if (entity == null)
                {
                    return await Task.FromResult<Result<UserModel>>(new Result<UserModel>(new BusinessException(new ValidationResult("User doesn't exists"))));
                }
                else
                {
                    var model=this.mapper.Map<UserModel>(entity);
                    return await Task.FromResult<Result<UserModel>>(new Result<UserModel>(model));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<UserModel>>(new Result<UserModel>(ex));
            }
        }

        public async Task<Result<UserModel[]>> GetAllUsersAsync()
        {
            try
            {
                var entity = await this.repository.GetAllUsersAsync();
                if (entity == null)
                {
                    return await Task.FromResult<Result<UserModel[]>>(new Result<UserModel[]>(new BusinessException(new ValidationResult("User doesn't exists"))));
                }
                else
                {
                    var model = this.mapper.Map<UserModel[]>(entity);
                    return await Task.FromResult<Result<UserModel[]>>(new Result<UserModel[]>(model));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<UserModel[]>>(new Result<UserModel[]>(ex));
            }
        }

        public async Task<Result<UserModel>> UpdateUserAsync(string loggedInUser, UserModel user)
        {
            try
            {
                var results = await this.validator.ValidateAsync(loggedInUser, user);
                if (results != null && results.Any())
                {
                    return await Task.FromResult<Result<UserModel>>(new Result<UserModel>(new BusinessException(results)));
                }
                var existingEntity=await this.repository.GetUserAsync(user.UID);
                if(existingEntity != null)
                {
                    existingEntity = this.mapper.Map<UserModel,User>(user,existingEntity);
                    var role = this.uow.RolesRepository.GetAllRoles().Where(x => x.Name == user.Role.Name).FirstOrDefault();
                    if (role != null)
                    {
                        existingEntity.UserType = GetUserType(user.Role);
                        existingEntity.RoleUID = role.UID;
                        existingEntity.LastUpdatedBy = loggedInUser;
                        existingEntity.LastUpdatedDate = DateTime.Now;
                        await this.repository.UpdateUserAsync(existingEntity);
                        if (await this.uow.SaveChangesAsync() > 0)
                        {
                            var updatedUser = await this.repository.GetUserAsync(user.UID);
                            var updatedUserModel = this.mapper.Map<UserModel>(updatedUser);
                            return await Task.FromResult<Result<UserModel>>(new Result<UserModel>(updatedUserModel));
                        }
                        else
                        {
                            return await Task.FromResult<Result<UserModel>>(new Result<UserModel>(new BusinessException(new ValidationResult("Unable to save user to database."))));
                        }
                    }
                    else
                    {
                        return await Task.FromResult<Result<UserModel>>(new Result<UserModel>(new BusinessException(
                            new ValidationResult("Unable to map new role to user."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<UserModel>>(new Result<UserModel>(new BusinessException(new ValidationResult("Unable to update user as it doesnt exists in database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<UserModel>>(new Result<UserModel>(ex));
            }
        }

        private int GetUserType(RoleModel role)
        {
            if (string.Equals(role.Name, RoleConstant.Admin))
            {
                return (int)UserType.Admin;
            }
            if (string.Equals(role.Name, RoleConstant.Consultant))
            {
                return (int)UserType.Consultant;
            }
            if (string.Equals(role.Name, RoleConstant.University))
            {
                return (int)UserType.University;
            }
            if (string.Equals(role.Name, RoleConstant.Student))
            {
                return (int)UserType.Student;
            }
            if (string.Equals(role.Name, RoleConstant.Landlord))
            {
                return (int)UserType.Landlord;
            }
            return -1;
        }
    }
}
