using Core.Entities;

namespace Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
