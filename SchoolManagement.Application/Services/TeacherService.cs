using SchoolManagement.Application.DTOs;
//using SchoolManagement.Application.Interfaces;
using SchoolManagement.Core.Entities;
//using SchoolManagement.Domain.Entities;
//using SchoolManagement.Domain.Interfaces;
using SchoolManagementMVC.SchoolManagement.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SchoolManagementMVC.SchoolManagement.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ICourseRepository _courseRepository;

        public TeacherService(ITeacherRepository teacherRepository, ICourseRepository courseRepository)
        {
            _teacherRepository = teacherRepository;
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CreateTeacherDTO>> GetAllTeachersAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return teachers.Select(t => new CreateTeacherDTO
            {
                Id = t.TeacherID,
                FirstName = t.FirstName,
                Email = t.Email
            });
        }

        public async Task<CreateTeacherDTO> GetTeacherByIdAsync(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher == null) return null;

            return new CreateTeacherDTO
            {
                Id = teacher.TeacherID,
                FirstName = teacher.FirstName,
                Email = teacher.Email
            };
        }

        public async Task CreateTeacherAsync(CreateTeacherDTO createTeacherDto, Teacher teacher)
        {
            //{
            //    FirstName = ,
            //    LastName = ,
            //    Email = 
            //    //Department = createTeacherDto.Department
            //};

            await _teacherRepository.AddAsync(teacher);
        }

        public async Task UpdateTeacherAsync(int id, UpdateTeacherDTO updateTeacherDto)
        {
            var teacher = await _teacherRepository.GetByIdAsync(updateTeacherDto.Id);
            if (teacher == null) return;

            teacher.FirstName = updateTeacherDto.FirstName;
            teacher.Email = updateTeacherDto.Email;
            teacher.LastName = updateTeacherDto.LastName;

            await _teacherRepository.UpdateAsync(teacher);
        }

        public async Task DeleteTeacherAsync(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher != null)
            {
                await _teacherRepository.DeleteAsync(teacher.TeacherID);
            }
        }

        // Implementación del método GetCoursesByTeacherAsync
        public async Task<IEnumerable<CreateCourseDTO>> GetCoursesByTeacherAsync(int teacherId)
        {
            //var courses = await _courseRepository.GetCoursesByTeacherIdAsync(teacherId);
            //var courses = await _courseRepository.GetByIdAsync(teacherId).ToString();
            var courses = await _courseRepository.GetAllAsync();
            //if (courses == null || !courses.Any())
            //{
            //    // Si no se encuentran cursos para este teacherId, devolver una lista vacía
            //    return Enumerable.Empty<CreateCourseDTO>();
            //}

            //return courses.Select(c => new CreateCourseDTO
            //{
            //    TeacherID = c.Id,
            //    Name = c.Name,
            //    Description = c.Description
            //});
            return (IEnumerable<CreateCourseDTO>)courses;
            //{
            //    TeacherID = c.TeacherId,  // Asumiendo que los cursos tienen una propiedad TeacherId
            //    Name = c.Name,
            //    Description = c.Description
            //});
        }
    }
}
