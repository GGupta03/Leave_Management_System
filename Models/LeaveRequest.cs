using Leave_Management_System.Enums;
using Leave_Management_System.Models;

namespace Leave_Management_System.Models
{
    public class LeaveRequest
    {
        public int LeaveId { get; set; }
        public int EmployeeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveStatus Status { get; set; }
    }
}





