using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Core.Entities;

namespace SchoolManagementMVC.SchoolManagement.Application.Services
{   
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task CreateCourseAsync(CreateCourseDTO courseDTO);
        Task UpdateCourseAsync(int id, UpdateCourseDTO courseDTO);
        Task DeleteCourseAsync(int id);
    }

}
