using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Entities;
//using SchoolManagement.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SchoolManagementMVC.SchoolManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets para las entidades
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }

        // Si necesitas hacer configuraciones adicionales para las entidades, sobreescribe OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
