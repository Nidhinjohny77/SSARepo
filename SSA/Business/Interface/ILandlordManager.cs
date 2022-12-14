

namespace Business.Interface
{
    public interface ILandlordManager
    {
        Task<Result<LandlordModel>> CreateLandlordProfileAysnc(string loggedInUser, LandlordModel landlord);
        Task<Result<LandlordModel>> UpdateLandlordProfileAsync(string loggedInUser, LandlordModel landlord);
        Task<Result<LandlordModel>> GetLandlordProfileAsync(string loggedInUser);
        Task<Result<bool>> DeleteLandlordProfileAsync(string loggedInUser);
    }
}
