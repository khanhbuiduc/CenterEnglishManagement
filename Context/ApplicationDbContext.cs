using CenterEnglishManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CenterEnglishManagement.Context
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
            
        }
        /*public DbSet<YourEntity> YourEntities { get; set; }*/
        public DbSet<User> Users { get; set; }
    }
}
