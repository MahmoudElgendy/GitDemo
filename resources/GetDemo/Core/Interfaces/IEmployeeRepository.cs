using Core.Entities;

namespace Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task InsertAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task Deleteasync(Employee employee);
    }
}
