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
        public StudentRepository(ApplicationDbContext context) : base(context)
//public StudentRepository(DbContext context) : base((ApplicationDbContext)context)
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

        public async Task DeleteAsync(int id)
        {
            //throw new NotImplementedException();
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync(StudentFilterDTO filter)
        {
            //throw new NotImplementedException();
            var query = _context.Students.AsQueryable();

            // Aplicar filtros si existen
            if (!string.IsNullOrEmpty(filter.FirstName))
            {
                query = query.Where(s => s.FirstName.Contains(filter.FirstName));
            }

            if (!string.IsNullOrEmpty(filter.LastName))
            {
                query = query.Where(s => s.LastName.Contains(filter.LastName));
            }

            // Puedes agregar más filtros según sea necesario

            return await query.ToListAsync();
        }
    }
}
