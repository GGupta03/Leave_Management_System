using Leave_Management_System.DTO;
using Leave_Management_System.Enums;
using Leave_Management_System.Models;

namespace Leave_Management_System.Servies.Interface
{
    public interface ILeaveService
    {
        void ApplyLeave(ApplyLeaveDto dto);
        IEnumerable<LeaveRequest> GetAllLeaves();
        IEnumerable<LeaveRequest> GetLeavesByEmployee(int employeeId);
        IEnumerable<LeaveRequest> GetLeavesByStatus(LeaveStatus status);
        void UpdateLeave(UpdateLeaveDto dto);
        void CancelLeave(int leaveId);
    }
}


