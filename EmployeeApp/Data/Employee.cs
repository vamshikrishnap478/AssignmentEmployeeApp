using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Data
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Designation { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public decimal? Salary { get; set; }
        public string? Gender { get; set; }
        public string? State { get; set; }
    }
}
