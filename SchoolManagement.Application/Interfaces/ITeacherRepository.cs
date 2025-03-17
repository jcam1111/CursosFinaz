using System.Collections.Generic;
    using System.Threading.Tasks;
    using SchoolManagement.Core.Entities;
    //using SchoolManagement.Domain.Entities;

namespace SchoolManagementMVC.SchoolManagement.Application.Interfaces
{    
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(int id);
        Task AddAsync(Teacher teacher);
        Task UpdateAsync(Teacher teacher);
        Task DeleteAsync(int id);
    }

}
