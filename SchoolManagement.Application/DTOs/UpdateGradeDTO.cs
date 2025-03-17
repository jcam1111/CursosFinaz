using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.DTOs
{
    public class UpdateGradeDTO
    {
        public int Id { get; set; }

        [Required]
        public int StudentID { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "Grade must be between 0 and 10.")]
        public decimal Grade { get; set; }
    }

}
