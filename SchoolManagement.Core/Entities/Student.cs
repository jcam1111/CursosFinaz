﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Entities
{
    public class Student
    {
        public int StudentID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 100 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 100 characters.")]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

}
