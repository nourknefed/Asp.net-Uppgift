using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Models;
using System;
using System.Collections.Generic;
using System.Text;
using School.Models.ViewModels;

namespace School.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<StudentSchool> StudentSchools { get; set; }
        public DbSet<TeacherSchool> TeacherSchools { get; set; }
        public DbSet<School.Models.ViewModels.TeacherViewModel> TeacherViewModel { get; set; }
        public DbSet<School.Models.ViewModels.StudentViewModel> StudentViewModel { get; set; }

       
    }
}
