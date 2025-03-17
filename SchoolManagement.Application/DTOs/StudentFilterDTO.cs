namespace SchoolManagementMVC.SchoolManagement.Application.DTOs
{
    public class StudentFilterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDateFrom { get; set; }
        public DateTime? BirthDateTo { get; set; }
    }
}
