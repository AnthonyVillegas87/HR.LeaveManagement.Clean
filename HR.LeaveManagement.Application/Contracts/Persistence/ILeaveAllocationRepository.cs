using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
    Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails();
    Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId);
    Task<bool> IsLeaveAllocationExist(int leaveTypeId, string userId, int period);
    Task AddLeaveAllocation(List<LeaveAllocation> allocations);
    Task<LeaveAllocation> GetUserAllocations(int leaveTypeId, string userId);
}