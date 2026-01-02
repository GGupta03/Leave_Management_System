using Leave_Management_System.Enums;

namespace Leave_Management_System.DTO
{
    public class UpdateLeaveDto
    {
        public int LeaveId { get; set; }
        public LeaveType LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
