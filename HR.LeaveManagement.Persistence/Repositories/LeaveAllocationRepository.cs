using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
    {
        
    }

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        var leaveAllocation = await _dbContext.LeaveAllocations
            .Include(x => x.LeaveType)
            .FirstOrDefaultAsync(x => x.Id == id);
        return leaveAllocation;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
    {
        var leaveAllocations = await _dbContext.LeaveAllocations
            .Include(x => x.LeaveType)
            .ToListAsync();
        
        return leaveAllocations;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
    {
        var leaveAllocations = await _dbContext.LeaveAllocations
            .Where(q => q.EmployeeId == userId)
            .Include(q => q.LeaveType)
            .ToListAsync();
        return leaveAllocations;
    }

    public async Task<bool> IsLeaveAllocationExist(int leaveTypeId, string userId, int period)
    {
        return await _dbContext.LeaveAllocations
            .AnyAsync(q => q.EmployeeId == userId 
                           && q.LeaveTypeId == leaveTypeId 
                           && q.Period == period);
    }

    public async Task AddLeaveAllocation(List<LeaveAllocation> allocations)
    {
        await _dbContext.AddRangeAsync(allocations);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<LeaveAllocation> GetUserAllocations(int leaveTypeId, string userId)
    {
        return await _dbContext.LeaveAllocations
            .FirstOrDefaultAsync(q => q.EmployeeId == userId 
                                      && q.LeaveTypeId == leaveTypeId);
    }
}