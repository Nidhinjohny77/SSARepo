
namespace DataAccess.Interface
{
    public interface IUniversityRepository
    {
        Task<bool> AddUniversityAsync(University university);
        Task<bool> UpdateUniversityAsync(University university);
        Task<bool> DeleteUniversityAsync(University university);
        Task<University> GetUniversityByIdAsync(string uid);
        Task<University> GetUniversityByNameAsync(string name);
        IQueryable<University> GetAllUniversities();
    }
}
