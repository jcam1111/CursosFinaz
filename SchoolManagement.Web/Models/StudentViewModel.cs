//using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementMVC.SchoolManagement.Web.Models
{
    public class StudentViewModel
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
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(15, ErrorMessage = "Phone number cannot be longer than 15 characters.")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(250, ErrorMessage = "Address cannot be longer than 250 characters.")]
        public string Address { get; set; }

        // Relaciones o propiedades relacionadas con otras entidades
        public int? CourseId { get; set; } // Para relacionar con un curso si es necesario
        public string CourseName { get; set; } // Nombre del curso asignado al estudiante si es necesario

        // Propiedades de auditoría (si las necesitas)
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        // Propiedades adicionales si es necesario
        public string FullName => $"{FirstName} {LastName}"; // Nombre completo del estudiante
    }
}
