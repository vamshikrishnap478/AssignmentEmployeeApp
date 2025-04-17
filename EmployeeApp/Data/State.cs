using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Data
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string? StateName { get; set; }
    }
}
