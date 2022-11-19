
namespace DataAccess.Interface
{
    public interface ILandlordRepository
    {
        Task<Landlord> AddLandlordAsync(Landlord landlord);
        Task<Landlord> UpdateLandlordAsync(Landlord landlord);
        Task<bool> DeleteLandlordAsync(Landlord landlord);
        Task<Landlord> GetLandlordByProfileAsync(string profileUID);
        Task<Landlord> GetLandlordByIdAsync(string uid);
        Task<Landlord> GetLandlordByNameAsync(string name);
        IQueryable<Landlord> GetAllLandlords();
    }
}
