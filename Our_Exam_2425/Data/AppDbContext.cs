using Microsoft.EntityFrameworkCore;
using Our_Exam_2425.Model;

namespace Our_Exam_2425.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }
        public DbSet<Game> Games { get; set; } = null!;
    }

}
