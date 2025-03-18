using SchoolManagementMVC.SchoolManagement.Application.Interfaces;
using SchoolManagementMVC.SchoolManagement.Application.DTOs;
//using SchoolManagementMVC.SchoolManagement.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Services;
using SchoolManagement.Core.Entities;

namespace SchoolManagementMVC.SchoolManagement.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        // Constructor con inyección de dependencias
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // Obtener todos los estudiantes
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            var studentDtos = new List<Student>();

            foreach (var student in students)
            {
                studentDtos.Add(new Student
                {
                    StudentID = student.StudentID,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    //EnrollmentDate = student.EnrollmentDate
                });
            }

            return studentDtos;
        }

        // Obtener un estudiante por ID
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return null;

            return new Student
            {
                StudentID = student.StudentID,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                //EnrollmentDate = student.EnrollmentDate
            };
        }

        // Crear un nuevo estudiante
        public async Task<bool> CreateStudentAsync(CreateStudentDTO createStudentDto)
        {
            var student = new Student
            {
                FirstName = createStudentDto.FirstName,
                LastName = createStudentDto.LastName,
                Email = createStudentDto.Email,
                //EnrollmentDate = createStudentDto.EnrollmentDate
            };
await _studentRepository.AddAsync(student);
            return true; 
        }

        // Actualizar un estudiante existente
        
        public async Task<bool> UpdateStudentAsync(int id, UpdateStudentDTO updateStudentDto)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return false;

            student.FirstName = updateStudentDto.FirstName;
            student.LastName = updateStudentDto.LastName;
            student.Email = updateStudentDto.Email;
await _studentRepository.UpdateAsync(student);
            return true;
        }

        // Eliminar un estudiante
        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return false;
await _studentRepository.DeleteAsync(student.StudentID);
            return true;
        }
    }
}
