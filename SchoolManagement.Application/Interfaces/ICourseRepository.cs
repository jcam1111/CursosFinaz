using System.Collections.Generic;
    using System.Threading.Tasks;
    using SchoolManagement.Core.Entities;
    //using SchoolManagement.Domain.Entities;

namespace SchoolManagementMVC.SchoolManagement.Application.Interfaces
{  
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int id);
        Task AddAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(int id);
    }

}
