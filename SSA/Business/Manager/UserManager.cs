
namespace Business.Manager
{
    public class UserManager : IUserManager
    {

        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        //private readonly IFileManager fileManager;
        //private readonly IUserValidator userValidator;
        //private readonly ICandidateValidator candidateValidator;
        //private readonly IFileValidator cvValidator;

        public UserManager(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
            //this.fileManager = fileManager;
            //this.userValidator = new UserValidator(uow);
            //this.candidateValidator = new CandidateValidator(uow);
            //this.cvValidator = new CVValidator(uow);
        }

        public async Task<StudentModel> CreateStudentProfileAysnc(string userUID, StudentModel student)
        {
            if (student != null && !string.IsNullOrEmpty(userUID))
            {
                //var results = await this.candidateValidator.Validate(userUID, student);
                //if (results != null && results.Any())
                //{
                //    throw new ValidationException(results);
                //}
                //if (!string.IsNullOrEmpty(userUID))
                //{
                //    var candidateEntity = this.mapper.Map<Student>(student);
                //    candidateEntity.UID = Guid.NewGuid().ToString();
                //    candidateEntity.UserUID = userUID;
                //    if (this.uow.StudentRepository.AddOrUpdateCandidate(candidateEntity))
                //    {
                //        if (await this.uow.SaveChangesAsync() > 0)
                //        {
                //            var entity = this.uow.CandidateRepository.GetCandidateByUID(candidateEntity.UID);
                //            var model = this.mapper.Map<StudentModel>(entity);
                //            return await Task.FromResult<StudentModel>(model);
                //        }
                //    }
                //}
            }
            return await Task.FromResult<StudentModel>(null);
        }

        public Task<LandlordModel> CreateLandlordProfileAysnc(string userUID, LandlordModel landlord)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> CreateUserAsync(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Task<StudentModel> UpdateStudentProfileAsync(string userUID, StudentModel candidate)
        {
            throw new NotImplementedException();
        }

        public Task<LandlordModel> UpdateLandlordProfileAsync(string userUID, LandlordModel landlord)
        {
            throw new NotImplementedException();
        }
    }
}
