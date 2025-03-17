using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Entities;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infrastructure.Data;
using SchoolManagementMVC.SchoolManagement.Application.Interfaces;
using SchoolManagementMVC.SchoolManagement.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementMVC.SchoolManagement.Infrastructure.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext _context;

        // Constructor que inyecta el contexto de base de datos
        public GradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todas las calificaciones
        public async Task<IEnumerable<Grade>> GetAllAsync()
        {
            return await _context.Grades.ToListAsync();
        }

        // Obtener una calificación por su ID
        public async Task<Grade> GetByIdAsync(int id)
        {
            return await _context.Grades
                                 .FirstOrDefaultAsync(g => g.Id == id);
        }

        // Agregar una nueva calificación
        public async Task AddAsync(Grade grade)
        {
            await _context.Grades.AddAsync(grade);
            await _context.SaveChangesAsync();
        }

        // Actualizar una calificación existente
        public async Task UpdateAsync(Grade grade)
        {
            _context.Grades.Update(grade);
            await _context.SaveChangesAsync();
        }

        // Eliminar una calificación
        public async Task DeleteAsync(Grade grade)
        {
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
        }

        // Obtener las calificaciones de un estudiante por su ID
        public async Task<IEnumerable<Grade>> GetGradesByStudentIdAsync(int studentId)
        {
            return await _context.Grades
                                 .Where(g => g.StudentId == studentId)
                                 .ToListAsync();
        }

        // Obtener las calificaciones de un curso por su ID
        public async Task<IEnumerable<Grade>> GetGradesByCourseIdAsync(int courseId)
        {
            return await _context.Grades
                                 .Where(g => g.CourseId == courseId)
                                 .ToListAsync();
        }
    }
}
