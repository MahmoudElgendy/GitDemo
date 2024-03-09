using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            return (employee != null) ? Ok(_mapper.Map<EmployeeDto>(employee)) : NotFound();
        }
        [HttpPost]
        public void Insert(EmployeeDto employeeDto)
        {
            _employeeRepository.Insert(_mapper.Map<Employee>(employeeDto));
        }
        [HttpPut]
        public void Update(EmployeeDto employeeDto)
        {
            _employeeRepository.Update(_mapper.Map<Employee>(employeeDto));
        }
        [HttpDelete]
        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
        }
    }
}
