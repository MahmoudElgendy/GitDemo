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
            return (employee == null) ? NotFound() : Ok(_mapper.Map<EmployeeDto>(employee));
        }
        [HttpPost]
        public async Task<IActionResult> Insert(EmployeeDto employeeDto)
        {
            await _employeeRepository.InsertAsync(_mapper.Map<Employee>(employeeDto));
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeDto.Id }, employeeDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, EmployeeDto employeeDto)
        {
            if (id != employeeDto.Id)
                return BadRequest();

            await _employeeRepository.UpdateAsync(_mapper.Map<Employee>(employeeDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employeeToDelete = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employeeToDelete == null)
                return NotFound();

            await _employeeRepository.Deleteasync(employeeToDelete);
            return NoContent();
        }
    }
}
