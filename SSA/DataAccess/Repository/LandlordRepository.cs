

namespace DataAccess.Repository
{
    public class LandlordRepository : ILandlordRepository
    {
        private readonly SSDbContext context;

        public LandlordRepository(SSDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddLandlordAsync(Landlord landlord)
        {
            var entry = this.context.Landlords.Add(landlord);
            return await Task.FromResult(entry.State == EntityState.Added);
        }

        public async Task<bool> DeleteLandlordAsync(Landlord landlord)
        {
            var entry = this.context.Landlords.Remove(landlord);
            return await Task.FromResult(entry.State == EntityState.Deleted);
        }

        public IQueryable<Landlord> GetAllLandlords()
        {
            return this.context.Landlords.AsQueryable();
        }

        public async  Task<Landlord> GetLandlordByProfileAsync(string profileUID)
        {
            return await this.context.Landlords.FirstOrDefaultAsync(x=>x.ProfileUID == profileUID);    
        }


        public async Task<Landlord> GetLandlordAsync(string userUID)
        {
            return await this.context.Landlords.FirstOrDefaultAsync(x => x.UserUID == userUID);
        }

        public async Task<bool> UpdateLandlordAsync(Landlord landlord)
        {
            var entry = this.context.Landlords.Update(landlord);
            return await Task.FromResult(entry.State == EntityState.Modified);
        }
    }
}
