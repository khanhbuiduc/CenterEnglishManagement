using CenterEnglishManagement.Models;
using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace CenterEnglishManagement.Context
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }
        /*public DbSet<YourEntity> YourEntities { get; set; }*/
        /*user*/
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Amins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents {  get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        /*other*/
        public DbSet<Class> classes { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<TuitionFee> TuitionFees { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        

    }
}
