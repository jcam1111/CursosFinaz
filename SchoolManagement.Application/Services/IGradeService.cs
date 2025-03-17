using SchoolManagement.Application.DTOs;
using SchoolManagement.Core.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;



namespace SchoolManagementMVC.SchoolManagement.Application.Services
{
    public interface IGradeService
    {
        Task<IEnumerable<Grade>> GetAllGradesAsync();
        Task<Grade> GetGradeByIdAsync(int id);
        Task CreateGradeAsync(CreateGradeDTO gradeDTO);
        Task UpdateGradeAsync(int id, UpdateGradeDTO gradeDTO);
        Task DeleteGradeAsync(int id);
    }
}
