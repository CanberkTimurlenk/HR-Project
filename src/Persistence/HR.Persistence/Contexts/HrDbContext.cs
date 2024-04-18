using HR.Domain.Entities.Abstract;
using HR.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HR.Persistence.Contexts;

public class HrDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Admin> Admins { get; set; }

    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<ExpenseType> ExpenseTypes { get; set; }
    public DbSet<CompanyType> CompanyTypes { get; set; }
    public DbSet<AdvanceType> AdvanceTypes { get; set; }

    public DbSet<Leave> Leaves { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Advance> Advances { get; set; }
    public DbSet<Company> Companies { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>()
                        .HasDiscriminator<string>("UserType")
                        .HasValue<Admin>("Admin")
                        .HasValue<Employee>("Employee")
                        .HasValue<Manager>("Manager");

        //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1430;Database=HrDb;User Id=SA;Password=Ab123456;TrustServerCertificate=True ");
    }

}
