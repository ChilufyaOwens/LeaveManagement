using AutoMapper;
using ErrorOr;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public record GetLeaveTypeDetailsQueryHanler(
    ILogger<GetLeaveTypeDetailsQueryHanler> Logger,
    IMapper Mapper,
    ILeaveTypeRepository LeaveTypeRepository) : IRequestHandler<GetLeaveTypeDetailsQuery, ErrorOr<LeaveTypeDetailsDto>>
{
    public async Task<ErrorOr<LeaveTypeDetailsDto>> Handle(GetLeaveTypeDetailsQuery query, CancellationToken cancellationToken)
    {
        Logger.LogInformation("Getting Leave Type Details for Id: {Id}", query.Id);
        
        var validator = new GetLeaveTypeDetailsQueryValidator();
        var validationResult = await validator.ValidateAsync(query, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            Logger.LogWarning("Leave Type Id has validation errors");
            return Error.Validation("GLQH-400", validationResult.ToString());
        }
        
        var leaveType = await LeaveTypeRepository.GetByIdAsync(query.Id);

        if (leaveType is null)
        {
            Logger.LogWarning("Leave Type Not Found for Id: {Id}", query.Id);
            return Error.NotFound("GLQH-404", "Leave Type Not Found.");
        }
        
        return Mapper.Map<LeaveTypeDetailsDto>(leaveType);
    }
}