using ErrorOr;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommand : IRequest<ErrorOr<Unit>>
{
    public int Id { get; set; }
}