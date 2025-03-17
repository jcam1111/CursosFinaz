using FluentValidation;
using SchoolManagement.Application.DTOs;

namespace SchoolManagementMVC.SchoolManagement.Application.Validations
{
    public class CourseValidator : AbstractValidator<CreateCourseDTO>
    {
        public CourseValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Course Name is required.")
                .Length(2, 100).WithMessage("Course Name must be between 2 and 100 characters.");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Course Description is required.")
                .Length(10, 500).WithMessage("Course Description must be between 10 and 500 characters.");

            RuleFor(c => c.TeacherID)
                .GreaterThan(0).WithMessage("Teacher ID must be a valid positive number.");
        }
    }
}
