using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository(LeaveManagementDbContext dbContext) : GenericRepository<LeaveRequest>(dbContext), ILeaveRequestRepository
{
    public Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestListWithDetails()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestListByEmployeeIdWithDetails(string userId)
    {
        throw new NotImplementedException();
    }
}