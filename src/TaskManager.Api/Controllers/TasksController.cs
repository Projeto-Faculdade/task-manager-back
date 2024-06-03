using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Application;
using TaskManager.Application.TasksToDo.Create;
using TaskManager.Application.TasksToDo.Delete;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/v1/tasks")]
public class TasksController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(TaskPostRequest request)
    {
        try
        {
            var validator = new TaskPostRequestValidator().Validate(request);

            var invalidRequest = !validator.IsValid;
            if (invalidRequest)
            {
                return BadRequest(validator.Errors.Select(e => e.ErrorMessage));
            }

            var response = await mediator.Send((TaskCreateRequest)request);

            return Created("api/v1/tasks/id", new { id = response });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException);
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTaskToDo(Guid id, [FromHeader(Name = "Accept-Language")] string preferredLanguage)
    {
        var request = new TaskGetByIdRequest
        {
            Id = id,
            PreferredLanguage = preferredLanguage
        };
        var result = await mediator.Send(request);

        if(result == default)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, TaskPostRequest request)
    {
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetTaskToDoAll([FromHeader(Name = "Accept-Language")] string preferredLanguage)
    {
        var request = new TaskGetAllRequest
        {
            PreferredLanguage = preferredLanguage
        };
        var result = await mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTaskToDo(Guid id)
    {
        var request = new TaskToDoDeleteRequest
        {
            Id = id
        };
        await mediator.Send(request);
        
        return NoContent();
    }
}