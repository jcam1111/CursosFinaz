using FluentValidation;
using SchoolManagement.Application.DTOs;

namespace SchoolManagementMVC.SchoolManagement.Application.Validations
{
    public class StudentValidator : AbstractValidator<CreateStudentDTO>
    {
        public StudentValidator()
        {
            RuleFor(s => s.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters.");

            RuleFor(s => s.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.");

            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be a valid email address.");

            RuleFor(s => s.BirthDate)
                .NotNull().WithMessage("Birth Date is required.")
                .LessThan(DateTime.Now).WithMessage("Birth Date must be in the past.");
        }
    }
}
