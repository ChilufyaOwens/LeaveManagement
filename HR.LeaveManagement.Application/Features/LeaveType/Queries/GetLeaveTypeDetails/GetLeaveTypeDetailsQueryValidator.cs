using FluentValidation;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryValidator : AbstractValidator<GetLeaveTypeDetailsQuery>
{
    public GetLeaveTypeDetailsQueryValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();
    }
}