using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementMVC.SchoolManagement.Web.Models
{
    public class TeacherViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "First Name cannot be longer than 100 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Last Name cannot be longer than 100 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150, ErrorMessage = "Email cannot be longer than 150 characters.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(15, ErrorMessage = "Phone number cannot be longer than 15 characters.")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Department")]
        [StringLength(100, ErrorMessage = "Department name cannot be longer than 100 characters.")]
        public string Department { get; set; }

        // Relaciones con otras entidades si es necesario (por ejemplo, cursos asignados)
        public int? CourseId { get; set; }
        public string CourseName { get; set; } // Nombre del curso asignado al profesor

        // Auditoría
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        // Propiedad adicional para el nombre completo del profesor
        public string FullName => $"{FirstName} {LastName}";
    }
}
