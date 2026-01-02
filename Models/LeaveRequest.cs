using Leave_Management_System.Enums;
using Leave_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Leave_Management_System.Models
{
    
    public class LeaveRequest
    {
        [Key]
        public int LeaveId { get; set; }
        public int EmployeeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveStatus Status { get; set; }
    }
}





