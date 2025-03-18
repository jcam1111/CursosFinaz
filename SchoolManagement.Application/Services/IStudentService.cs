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
        Task<bool> CreateStudentAsync(CreateStudentDTO studentDTO);
        Task<bool> UpdateStudentAsync(int id, UpdateStudentDTO studentDTO);
        Task<bool> DeleteStudentAsync(int id);
    }

}
