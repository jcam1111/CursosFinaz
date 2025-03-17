 using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Core.Entities;
    

namespace SchoolManagementMVC.SchoolManagement.Application.Services
{   
    public interface ITeacherService
    {
        Task<IEnumerable<CreateTeacherDTO>> GetAllTeachersAsync();
        Task<CreateTeacherDTO> GetTeacherByIdAsync(int id);
        Task CreateTeacherAsync(CreateTeacherDTO teacherDTO);
        Task UpdateTeacherAsync(int id, UpdateTeacherDTO teacherDTO);
        Task DeleteTeacherAsync(int id);

        Task<IEnumerable<CreateCourseDTO>> GetCoursesByTeacherAsync(int teacherId);
    }

}
