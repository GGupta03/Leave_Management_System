using Leave_Management_System.Data;
using Leave_Management_System.DTO;
using Leave_Management_System.Enums;
using Leave_Management_System.Models;
using Leave_Management_System.Servies.Interface;


public class LeaveService : ILeaveService
{
    private readonly AppDbContext _context;

    public LeaveService(AppDbContext context)
    {
        _context = context;
    }

    public void ApplyLeave(ApplyLeaveDto dto)
    {
        if (dto.StartDate >= dto.EndDate)
            throw new Exception("Start date must be before end date");

        int leaveDays = (dto.EndDate - dto.StartDate).Days + 1;
        if (leaveDays > 10)
            throw new Exception("Leave cannot exceed 10 days");

        var leave = new LeaveRequest
        {
            EmployeeId = dto.EmployeeId,
            LeaveType = dto.LeaveType,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Status = LeaveStatus.Pending
        };

        _context.LeaveRequests.Add(leave);
        _context.SaveChanges();
    }

    public IEnumerable<LeaveRequest> GetAllLeaves()
    {
        return _context.LeaveRequests.ToList();
    }

    public IEnumerable<LeaveRequest> GetLeavesByEmployee(int employeeId)
    {
        return _context.LeaveRequests
            .Where(l => l.EmployeeId == employeeId)
            .ToList();
    }

    public IEnumerable<LeaveRequest> GetLeavesByStatus(LeaveStatus status)
    {
        return _context.LeaveRequests
            .Where(l => l.Status == status)
            .ToList();
    }

    public void UpdateLeave(UpdateLeaveDto dto)
    {
        var leave = _context.LeaveRequests.Find(dto.LeaveId);

        if (leave == null)
            throw new Exception("Leave not found");

        if (leave.Status != LeaveStatus.Pending)
            throw new Exception("Only pending leave can be modified");

        if (dto.StartDate >= dto.EndDate)
            throw new Exception("Invalid date range");

        leave.LeaveType = dto.LeaveType;
        leave.StartDate = dto.StartDate;
        leave.EndDate = dto.EndDate;

        _context.SaveChanges();
    }

    public void CancelLeave(int leaveId)
    {
        var leave = _context.LeaveRequests.Find(leaveId);

        if (leave == null)
            throw new Exception("Leave not found");

        if (DateTime.Now >= leave.StartDate)
            throw new Exception("Cannot cancel after leave has started");

        _context.LeaveRequests.Remove(leave);
        _context.SaveChanges();
    }
}

