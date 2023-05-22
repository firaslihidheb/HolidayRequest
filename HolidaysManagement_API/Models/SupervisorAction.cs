using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HolidaysManagement_API.Models
{
    public class SupervisorAction
    {
        [Key]
        public int ActionId { get; set; }

        [Required]
        public int RequestId { get; set; }

        [Required]
        public int SupervisorId { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        public DateTime? ValidationDate { get; set; }

        [Required]
        public bool IsApproved { get; set; }

        public string Comments { get; set; }
    }
}
