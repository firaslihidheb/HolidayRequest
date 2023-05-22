using System.ComponentModel.DataAnnotations;

namespace HolidaysManagement_API.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
