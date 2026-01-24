using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers;

public class LeaveTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<List<LeaveTypeDto>> GetAllLeaveTypes()
    {   
        var leaveTypes = await _mediator.Send(new GetLeaveTypesQuery());
        return leaveTypes;
    }
    
    [HttpGet("{id}")]
    public ActionResult<LeaveTypeDto> GetLeaveTypeById(int id)
    {
        return Ok(new LeaveTypeDto());
    }
    
    [HttpPost]
    public ActionResult CreateLeaveType(CreateLeaveTypeCommand command)
    {
        return Ok();
    }
    
    [HttpPut("{id}")]
    public ActionResult UpdateLeaveType(int id, UpdateLeaveTypeCommand command)
    {
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult DeleteLeaveType(int id)
    {
        return Ok();
    }
}