namespace HolidaysManagement_API.Dtos
{
    public class SupervisorActionDTO
    {
        public int ActionId { get; set; }
        public int RequestId { get; set; }
        public int SupervisorId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ValidationDate { get; set; }
        public bool IsApproved { get; set; }
        public string Comments { get; set; }
    }
}
