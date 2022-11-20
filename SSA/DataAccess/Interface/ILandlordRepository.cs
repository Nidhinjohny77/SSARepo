
namespace DataAccess.Interface
{
    public interface ILandlordRepository
    {
        Task<bool> AddLandlordAsync(Landlord landlord);
        Task<bool> UpdateLandlordAsync(Landlord landlord);
        Task<bool> DeleteLandlordAsync(Landlord landlord);
        Task<Landlord> GetLandlordByProfileAsync(string profileUID);
        Task<Landlord> GetLandlordAsync(string userUID);
        IQueryable<Landlord> GetAllLandlords();
    }
}
