using System.Collections.Generic;
    using System.Threading.Tasks;
    using SchoolManagement.Core.Entities;
    //using SchoolManagement.Domain.Entities;

namespace SchoolManagementMVC.SchoolManagement.Application.Interfaces
{  
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetAllAsync();
        Task<Grade> GetByIdAsync(int id);
        Task AddAsync(Grade grade);
        Task UpdateAsync(Grade grade);
        Task DeleteAsync(int id);
    }

}
