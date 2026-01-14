using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(p => p)
            .MustAsync(LeaveTypeMustExist)
            .WithMessage("{PropertyName} must be present");

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(p => p.DefaultDays)
            .LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
            .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");

        RuleFor(p => p)
            .MustAsync(LeaveTypeNameUnique)
            .WithMessage("Leave type with same name already exists");
    }

    private async Task<bool> LeaveTypeMustExist(UpdateLeaveTypeCommand command, CancellationToken token)
    {
       return await _leaveTypeRepository.IsLeaveTypeExist(command.Name);
    }

    private async Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token)
    {
        return await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    }
}
