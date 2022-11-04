
namespace DataAccess.Repository
{
    public class StudentRepository : IStudentRepository
    {
        SSDbContext context = null;
        public StudentRepository(SSDbContext context)
        {
            this.context = context;
        }
        public Task<Student> AddStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<Student[]> GetAllStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
