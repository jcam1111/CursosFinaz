using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementMVC.SchoolManagement.Web.Models
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Course Name cannot be longer than 200 characters.")]
        [Display(Name = "Course Name")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Course Description cannot be longer than 500 characters.")]
        [Display(Name = "Course Description")]
        public string Description { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Credits must be between 1 and 10.")]
        [Display(Name = "Credits")]
        public int Credits { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        // Relaciones (si el curso está asociado a un profesor)
        public int? TeacherId { get; set; }  // ID del profesor que imparte el curso
        public string TeacherFullName { get; set; }  // Nombre del profesor asignado al curso

        // Propiedades de auditoría
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        // Propiedades adicionales si son necesarias
        public string CourseDuration => $"{StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}"; // Duración del curso
    }
}
