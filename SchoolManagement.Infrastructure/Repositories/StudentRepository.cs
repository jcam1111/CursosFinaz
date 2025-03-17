using SchoolManagement.Core.Entities;
//using SchoolManagement.Domain.Entities;
using SchoolManagementMVC.SchoolManagement.Infrastructure.Data;

namespace SchoolManagementMVC.SchoolManagement.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(ApplicationDbContext context) : base(context) { }

        // Métodos específicos para los estudiantes si es necesario
    }
}
