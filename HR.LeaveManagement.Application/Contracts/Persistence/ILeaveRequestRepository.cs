using HR.LeaveManagement.Application.Contracts.Persistence.Common;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
    Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestListWithDetails();
    Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestListByEmployeeIdWithDetails(string userId);
}