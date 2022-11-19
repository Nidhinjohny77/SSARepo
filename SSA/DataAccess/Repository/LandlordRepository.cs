

namespace DataAccess.Repository
{
    public class LandlordRepository : ILandlordRepository
    {
        private readonly SSDbContext context;

        public LandlordRepository(SSDbContext context)
        {
            this.context = context;
        }

        public Task<Landlord> AddLandlordAsync(Landlord landlord)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteLandlordAsync(Landlord landlord)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Landlord> GetAllLandlords()
        {
            throw new NotImplementedException();
        }

        public Task<Landlord> GetLandlordByIdAsync(string uid)
        {
            throw new NotImplementedException();
        }

        public Task<Landlord> GetLandlordByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Landlord> GetLandlordByProfileAsync(string profileUID)
        {
            throw new NotImplementedException();
        }

        public Task<Landlord> UpdateLandlordAsync(Landlord landlord)
        {
            throw new NotImplementedException();
        }
    }
}
