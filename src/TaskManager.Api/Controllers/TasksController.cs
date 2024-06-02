using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Application.TasksToDo.Create;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/v1/tasks")]
public class TasksController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(TaskToDoPostRequest request)
    {
        try
        {
            var validator = new TaskPutRequestValidator().Validate(request);

            var invalidRequest = !validator.IsValid;
            if (invalidRequest)
            {
                return BadRequest(validator.Errors.Select(e => e.ErrorMessage));
            }

            var response = await mediator.Send((TaskToDoCreateRequest)request);

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
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, TaskToDoPostRequest request)
    {
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetTaskToDoAll([FromHeader(Name = "Accept-Language")] string preferredLanguage)
    {
        await Task.Delay(100);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTaskToDo(Guid id)
    {
        await Task.Delay(100);
        return NoContent();
    }
}