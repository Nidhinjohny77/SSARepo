
namespace DataAccess.Repository
{
    public class StudentRepository : IStudentRepository
    {
        SSDbContext context = null;
        public StudentRepository(SSDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> AddStudentAsync(StudentProfile student)
        {
            var entry=this.context.Students.Add(student);
            return await Task.FromResult(entry.State==EntityState.Added);
        }

        public async Task<bool> DeleteStudentAsync(StudentProfile student)
        {
            var entry = this.context.Students.Remove(student);
            return await Task.FromResult(entry.State == EntityState.Deleted);
        }

        public IQueryable<StudentProfile> GetAllStudents()
        {
            return this.context.Students.AsQueryable();
        }

        public async Task<StudentProfile> GetStudentByCodeAsync(string securityCode)
        {
            return await this.context.Students.FirstOrDefaultAsync(x=>x.StudentSecurityCode== securityCode);
        }

        public async Task<StudentProfile> GetStudentByProfileAsync(string profileUID)
        {
            return await this.context.Students.FirstOrDefaultAsync(x => x.UID == profileUID);
        }

        public async Task<StudentProfile> GetStudentProfileAsync(string tenantUID)
        {
            return await this.context.Students.FirstOrDefaultAsync(x => x.TenantUID == tenantUID);
        }


        public async Task<bool> UpdateStudentAsync(StudentProfile student)
        {
            var entry = this.context.Students.Update(student);
            return await Task.FromResult(entry.State == EntityState.Modified);
        }
    }
}
