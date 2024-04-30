using AutoMapper;
using ErrorOr;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;

public record DeleteLeaveTypeCommandHandler(
    ILogger<DeleteLeaveTypeCommandHandler> Logger, 
    ILeaveTypeRepository LeaveTypeRepository) : IRequestHandler<DeleteLeaveTypeCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(DeleteLeaveTypeCommand command, CancellationToken cancellationToken)
    {
        Logger.LogInformation("Deleting Leave Type with Id: {Id}", command.Id);
        
        var leaveTypeToDelete = await LeaveTypeRepository.GetByIdAsync(command.Id);
        
        if (leaveTypeToDelete is null)
        {
            Logger.LogWarning("Leave Type Not Found for Id: {Id}", command.Id);
            return Error.NotFound("DLT-404", "Leave Type Not Found.");
        }
        
        await LeaveTypeRepository.DeleteAsync(leaveTypeToDelete);
        
        Logger.LogInformation("Leave Type successfully deleted with Id: {Id}", leaveTypeToDelete.Id);
        return Unit.Value;
    }
}