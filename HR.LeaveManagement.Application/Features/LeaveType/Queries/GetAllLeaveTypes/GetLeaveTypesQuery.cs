using ErrorOr;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetLeaveTypesQuery : IRequest<ErrorOr<List<LeaveTypeDto>>>
{
    
}