using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()

        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(p => p.Id == id);
            return employee;
        }

        public async Task Insert(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var employeeInDb = await _context.Employees.FirstOrDefaultAsync(p => p.Id == id);
            if (employeeInDb != null)
            {
                _context.Employees.Remove(employeeInDb);
                await _context.SaveChangesAsync();
            }
        }
    }
}
