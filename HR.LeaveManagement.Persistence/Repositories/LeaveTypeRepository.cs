using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Contracts.Persistence.Common;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveTypeRepository(LeaveManagementDbContext dbContext) : GenericRepository<LeaveType>(dbContext), ILeaveTypeRepository
{
    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await dbContext.LeaveTypes.AnyAsync(lt => lt.Name == name);
    }
}