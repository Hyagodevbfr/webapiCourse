using Microsoft.EntityFrameworkCore;
using WebAPI_Employee.Models;

namespace WebAPI_Employee.DataContext;

public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}

    public DbSet<EmployeeModel> Employees { get; set; }
}
