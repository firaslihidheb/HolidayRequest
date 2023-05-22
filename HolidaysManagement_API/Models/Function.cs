using System.ComponentModel.DataAnnotations;

namespace HolidaysManagement_API.Models
{
    public class Function
    {
        
        [Key]
        public int FunctionId { get; set; }

        [Required]
        public string FunctionName { get; set; }

        public string Description { get; set; }

        // Other relevant properties as per your application's needs
    }
}

