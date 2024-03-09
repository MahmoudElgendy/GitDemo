using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class EmployeeDto
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string? MiddleName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public int? ManagerId { get; set; }
    }
}
