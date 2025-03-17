namespace SchoolManagementMVC.SchoolManagement.Application.DTOs
{
    public class GradeFilterDTO
    {
        public int? StudentID { get; set; }
        public int? CourseID { get; set; }
        public decimal? GradeFrom { get; set; }
        public decimal? GradeTo { get; set; }
    }

}
