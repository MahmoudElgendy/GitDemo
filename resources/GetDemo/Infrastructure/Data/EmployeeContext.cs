using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {


        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Employee>()
                .Property(p => p.MiddleName)
                .HasMaxLength(30);

            modelBuilder.Entity<Employee>()
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany()
                .HasForeignKey(e => e.ManagerId)
                .IsRequired(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.ManagerId)
                .IsRequired(false);

        }
    }
}
