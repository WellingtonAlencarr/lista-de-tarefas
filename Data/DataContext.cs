using Lista_de_Tarefas.Data.Map;
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
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
