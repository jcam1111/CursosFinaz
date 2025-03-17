using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementMVC.SchoolManagement.Web.Models
{
    public class GradeViewModel
    {
        public int Id { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100.")]
        [Display(Name = "Grade")]
        public double Grade { get; set; }

        [Required]
        [Display(Name = "Date Given")]
        public DateTime DateGiven { get; set; }

        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        // Propiedades relacionadas
        public string StudentFullName { get; set; }  // Nombre completo del estudiante
        public string CourseName { get; set; }  // Nombre del curso

        // Auditoría
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
