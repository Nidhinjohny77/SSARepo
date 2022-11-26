

namespace Business.Interface
{
    public interface ILandlordManager
    {
        Task<Result<LandlordModel>> CreateLandlordProfileAysnc(string userUID, LandlordModel landlord);
        Task<Result<LandlordModel>> UpdateLandlordProfileAsync(string userUID, LandlordModel landlord);
        Task<Result<LandlordModel>> GetLandlordProfileAsync(string userUID);
        Task<Result<bool>> DeleteLandlordProfileAsync(string userUID);
    }
}
