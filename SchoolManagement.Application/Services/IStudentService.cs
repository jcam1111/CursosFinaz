using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Application.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task CreateStudentAsync(CreateStudentDTO studentDTO);
        Task UpdateStudentAsync(int id, UpdateStudentDTO studentDTO);
        Task DeleteStudentAsync(int id);
    }

}
