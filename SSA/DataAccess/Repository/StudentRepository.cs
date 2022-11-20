
namespace DataAccess.Repository
{
    public class StudentRepository : IStudentRepository
    {
        SSDbContext context = null;
        public StudentRepository(SSDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> AddStudentAsync(Student student)
        {
            var entry=this.context.Students.Add(student);
            return await Task.FromResult(entry.State==EntityState.Added);
        }

        public async Task<bool> DeleteStudentAsync(Student student)
        {
            var entry = this.context.Students.Remove(student);
            return await Task.FromResult(entry.State == EntityState.Deleted);
        }

        public IQueryable<Student> GetAllStudents()
        {
            return this.context.Students.AsQueryable();
        }

        public async Task<Student> GetStudentByCodeAsync(string code)
        {
            return await this.context.Students.FirstOrDefaultAsync(x=>x.StudentCode==code);
        }

        public async Task<Student> GetStudentByProfileAsync(string profileUID)
        {
            return await this.context.Students.FirstOrDefaultAsync(x => x.ProfileUID == profileUID);
        }

        public async Task<Student> GetStudentProfileAsync(string UserUID)
        {
            return await this.context.Students.FirstOrDefaultAsync(x => x.UserUID == UserUID);
        }


        public async Task<bool> UpdateStudentAsync(Student student)
        {
            var entry = this.context.Students.Update(student);
            return await Task.FromResult(entry.State == EntityState.Modified);
        }
    }
}
