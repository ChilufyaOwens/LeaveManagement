using AutoMapper;
using ErrorOr;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public record GetLeaveTypesQueryHandler(
    IMapper Mapper, 
    ILeaveTypeRepository LeaveTypeRepository, 
    ILogger<GetLeaveTypesQueryHandler> Logger) : IRequestHandler<GetLeaveTypesQuery, ErrorOr<List<LeaveTypeDto>>>
{
    public async Task<ErrorOr<List<LeaveTypeDto>>> Handle(GetLeaveTypesQuery query, CancellationToken cancellationToken)
    {
        Logger.LogInformation("Getting all Leave Types");
        var allLeaveTypes = (await LeaveTypeRepository.GetAllAsync()).OrderBy(x => x.Name);
        return Mapper.Map<List<LeaveTypeDto>>(allLeaveTypes);
    }
}