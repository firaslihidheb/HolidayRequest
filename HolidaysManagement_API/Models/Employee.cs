using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HolidaysManagement_API.Models
{
    public class Employee : User
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [ForeignKey(nameof(SupervisorId))]
        public int SupervisorId { get; set; }

        [Required]
        public DateTime DateOfJoining { get; set; }

        [Required]
        public int FunctionId { get; set; }

        [ForeignKey(nameof(FunctionId))]
        public Function Function { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
