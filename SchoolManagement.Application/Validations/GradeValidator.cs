using FluentValidation;
using SchoolManagement.Application.DTOs;

namespace SchoolManagementMVC.SchoolManagement.Application.Validations
{
    public class GradeValidator : AbstractValidator<CreateGradeDTO>
    {
        public GradeValidator()
        {
            RuleFor(g => g.StudentID)
                .GreaterThan(0).WithMessage("Student ID must be a valid positive number.");

            RuleFor(g => g.CourseID)
                .GreaterThan(0).WithMessage("Course ID must be a valid positive number.");

            RuleFor(g => g.Grade)
                .InclusiveBetween(0, 10).WithMessage("Grade must be between 0 and 10.");
        }
    }
}
