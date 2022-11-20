
namespace Business.Interface
{
    public interface IUserManager
    {
        Task<UserModel> CreateUserAsync(UserModel user);
        Task<LandlordModel> CreateLandlordProfileAysnc(string userUID, LandlordModel landlord);
        Task<LandlordModel> UpdateLandlordProfileAsync(string userUID, LandlordModel landlord);
        Task<StudentModel> CreateStudentProfileAysnc(string userUID, StudentModel student);
        Task<StudentModel> UpdateStudentProfileAsync(string userUID, StudentModel candidate);
        
    }
}
