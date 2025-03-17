
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.Interfaces;
using SchoolManagement.Infrastructure.Repositories;
using SchoolManagement.Infrastructure.Services;
using SchoolManagementMVC.SchoolManagement.Application.Interfaces;
using SchoolManagementMVC.SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagementMVC.SchoolManagement.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Repositorios
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();

            // Servicios
            //services.AddScoped<EmailService>();

            return services;
        }
    }
}
