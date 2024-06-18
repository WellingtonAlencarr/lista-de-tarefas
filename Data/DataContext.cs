using Lista_de_Tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace Lista_de_Tarefas.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> TB_USER { get; set; }
        public DbSet<TaskModel> TB_TASK { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>().ToTable("TB_TASKS");
            modelBuilder.Entity<UserModel>().ToTable("TB_USERS");

            modelBuilder.Entity<UserModel>()
                .HasMany(e => e.Tasks)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired(false);
        }
    }
}
