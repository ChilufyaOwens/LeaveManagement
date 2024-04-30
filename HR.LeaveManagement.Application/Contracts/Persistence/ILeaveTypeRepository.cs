using HR.LeaveManagement.Application.Contracts.Persistence.Common;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
{
   // exist by name
   Task<bool> ExistsByNameAsync(string name);
   
}