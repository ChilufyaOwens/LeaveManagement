using ErrorOr;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommand : IRequest<ErrorOr<int>>
{
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}