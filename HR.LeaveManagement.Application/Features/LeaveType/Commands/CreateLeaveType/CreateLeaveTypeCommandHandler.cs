using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ErrorOr;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public record CreateLeaveTypeCommandHandler(
    ILogger<CreateLeaveTypeCommandHandler> Logger,
    IMapper Mapper,
    ILeaveTypeRepository LeaveTypeRepository) : IRequestHandler<CreateLeaveTypeCommand, ErrorOr<int>>
{
    public async Task<ErrorOr<int>> Handle(CreateLeaveTypeCommand command, CancellationToken cancellationToken)
    {
        Logger.LogInformation("Creating Leave Type");
        
        var validator = new CreateLeaveTypeCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            Logger.LogWarning("Leave Type has validation errors");
            return Error.Validation("CLT-400", validationResult.ToString());
        }
        
        // Check if the name already exists
        if (await LeaveTypeRepository.ExistsByNameAsync(command.Name))
        {
            Logger.LogWarning("Leave Type with name {Name} already exists", command.Name);
            return Error.Conflict("CLT-409", "Leave Type with the same name already exists.");
        }
        
        var leaveTypeToCreate =Mapper.Map<Domain.LeaveType>(command);
        
        leaveTypeToCreate = await LeaveTypeRepository.AddAsync(leaveTypeToCreate);
        
        Logger.LogInformation("Leave Type successfully created with Id: {Id}", leaveTypeToCreate.Id);
        return leaveTypeToCreate.Id;
    }
}