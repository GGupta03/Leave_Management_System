using Leave_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Leave_Management_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }

    }
}
