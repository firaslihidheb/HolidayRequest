using System.ComponentModel.DataAnnotations;

namespace HolidaysManagement_API.Dtos
{
    public class HolidayRequestDTO
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public int ApprovalMappingId { get; set; }


        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Status { get; set; }

        public string Reason { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
