using EmployeeApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employee { get; set; }
        DbSet<State> State { get; set; }
        int SaveChanges();
    }
}
