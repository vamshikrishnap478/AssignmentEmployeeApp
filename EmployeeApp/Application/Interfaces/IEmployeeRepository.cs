using EmployeeApp.Data;
using EmployeeApp.Model;

namespace EmployeeApp.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task AddAsync(EmployeeModel employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
        Task DeleteMultipleAsync(int[] ids);
        Task<bool> IsDuplicateAsync(string name, DateTime dob);
        Task<byte[]> GeneratePdf();
    }
}
