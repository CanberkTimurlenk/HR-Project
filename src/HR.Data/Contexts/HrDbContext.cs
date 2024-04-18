using HR.Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HR.Data.Contexts;

public class HrDbContext(DbContextOptions<HrDbContext> options) : DbContext(options)
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
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
