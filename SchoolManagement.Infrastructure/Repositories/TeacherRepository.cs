using Microsoft.EntityFrameworkCore;
//using SchoolManagement.Application.Interfaces;
using SchoolManagement.Core.Entities;
//using SchoolManagement.Domain.Entities;
//using SchoolManagement.Infrastructure.Data;
using SchoolManagementMVC.SchoolManagement.Application.Interfaces;
using SchoolManagementMVC.SchoolManagement.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementMVC.SchoolManagement.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        // Constructor
        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para obtener todos los profesores
        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        // Método para obtener un profesor por su ID
        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _context.Teachers
                .FirstOrDefaultAsync(t => t.TeacherID == id);
        }

        // Método para agregar un nuevo profesor
        public async Task AddAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        // Método para actualizar la información de un profesor
        public async Task UpdateAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
        }

        // Método para eliminar un profesor
        public async Task DeleteAsync(int id)
        {
            var teacher = await GetByIdAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }
        }

        // Método para obtener los profesores de un curso específico
        public async Task<IEnumerable<Teacher>> GetTeachersByCourseAsync(int courseId)
        {
            return await _context.Teachers
                .Where(t => t.Courses.Any(c => c.CourseID == courseId))
                .ToListAsync();
        }
    }
}
