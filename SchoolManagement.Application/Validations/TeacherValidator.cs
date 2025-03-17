using FluentValidation;
using SchoolManagement.Application.DTOs;

namespace SchoolManagementMVC.SchoolManagement.Application.Validations
{
    public class TeacherValidator : AbstractValidator<CreateTeacherDTO>
    {
        public TeacherValidator()
        {
            RuleFor(t => t.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters.");

            RuleFor(t => t.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.");

            RuleFor(t => t.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be a valid email address.");

            RuleFor(t => t.Subject)
                .NotEmpty().WithMessage("Subject is required.")
                .Length(2, 100).WithMessage("Subject must be between 2 and 100 characters.");
        }
    }
}
