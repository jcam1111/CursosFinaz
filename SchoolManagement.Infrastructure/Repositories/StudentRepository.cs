using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Entities;
using SchoolManagementMVC.SchoolManagement.Application.DTOs;
using SchoolManagementMVC.SchoolManagement.Application.Interfaces;

//using SchoolManagement.Domain.Entities;
using SchoolManagementMVC.SchoolManagement.Infrastructure.Data;

namespace SchoolManagementMVC.SchoolManagement.Infrastructure.Repositories
{
    //public class StudentRepository : BaseRepository<Student>
    //{
    //    public StudentRepository(ApplicationDbContext context) : base(context) { }

    //    // Métodos específicos para los estudiantes si es necesario
    //}
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context)
        {
        }

        // Puedes agregar lógica adicional si es necesario
        // Ejemplo: Buscar estudiantes por nombre
        public async Task<IEnumerable<Student>> GetStudentsByNameAsync(string name)
        {
            return await _context.Set<Student>()
                                 .Where(s => s.FirstName.Contains(name))
                                 .ToListAsync();
        }

        Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Student>> GetAllAsync(StudentFilterDTO filter)
        {
            throw new NotImplementedException();
        }
    }
}
