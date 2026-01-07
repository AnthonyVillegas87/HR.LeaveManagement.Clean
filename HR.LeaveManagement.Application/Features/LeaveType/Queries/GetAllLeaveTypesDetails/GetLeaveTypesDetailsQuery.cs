using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypesDetails;

public record GetLeaveTypesDetailsQuery(int Id) : IRequest<LeaveTypeDetailsDto>;