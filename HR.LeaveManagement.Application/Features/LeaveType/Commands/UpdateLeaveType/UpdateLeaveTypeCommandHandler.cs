using AutoMapper;
using ErrorOr;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public record UpdateLeaveTypeCommandHandler(
    ILogger<UpdateLeaveTypeCommandHandler> Logger,
    IMapper Mapper,
    ILeaveTypeRepository LeaveTypeRepository) : IRequestHandler<UpdateLeaveTypeCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(UpdateLeaveTypeCommand command, CancellationToken cancellationToken)
    {
        Logger.LogInformation("Updating Leave Type");
        
        var validator = new UpdateLeaveTypeCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            Logger.LogWarning("Leave Type has validation errors");
            return Error.Validation("ULT-400", validationResult.ToString());
        }
        
        var leaveType = await LeaveTypeRepository.GetByIdAsync(command.Id);
        
        if (leaveType is null)
        {
            Logger.LogWarning("Leave Type Not Found for Id: {Id}", command.Id);
            return Error.NotFound("ULT-404", "Leave Type Not Found.");
        }
        
        Mapper.Map(command, leaveType);
        
        await LeaveTypeRepository.UpdateAsync(leaveType);
        
        Logger.LogInformation("Leave Type successfully updated with Id: {Id}", leaveType.Id);
        return Unit.Value; 
    }
}