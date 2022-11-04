
namespace DataAccess.Interface
{
    public interface IUniversityRepository
    {
        Task<University> AddUniversityAsync(University university);
        Task<University> UpdateUniversityAsync(University university);
        Task<bool> DeleteUniversityAsync(University university);
        Task<University> GetUniversityByIdAsync(int id);
        Task<University> GetUniversityByNameAsync(string name);
        Task<University[]> GetAllUniversitiesAsync();
    }
}
