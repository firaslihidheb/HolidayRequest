namespace HolidaysManagement_API.Dtos
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int SupervisorId { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int FunctionId { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
