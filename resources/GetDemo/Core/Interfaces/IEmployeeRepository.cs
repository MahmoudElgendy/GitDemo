using Core.Entities;

namespace Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task Insert(Employee employee);
        Task Update(Employee employee);
        Task Delete(int id);
    }
}
