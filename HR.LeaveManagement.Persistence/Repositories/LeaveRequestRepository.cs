using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(HrDatabaseContext context) : base(context)
    {
        
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        var leaveRequests = await _dbContext.LeaveRequests
            .Include(x => x.LeaveType)
            .FirstOrDefaultAsync(x => x.Id == id);
           
        return leaveRequests;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
    {
       var leaveRequests = await _dbContext.LeaveRequests
           .Include(x => x.LeaveType)
           .ToListAsync();
       return leaveRequests;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
    {
        var leaveRequests = await _dbContext.LeaveRequests
            .Where(q => q.RequestingEmployeeId == userId)
            .Include(q => q.LeaveType)
            .ToListAsync();
        return leaveRequests;
    }
}