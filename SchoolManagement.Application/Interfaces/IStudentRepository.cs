 using System.Collections.Generic;
    using System.Threading.Tasks;
using SchoolManagement.Core.Entities;
using SchoolManagementMVC.SchoolManagement.Application.DTOs;
//using SchoolManagement.Domain.Entities;

namespace SchoolManagementMVC.SchoolManagement.Application.Interfaces
{ 
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync(StudentFilterDTO filter);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
    }

}
