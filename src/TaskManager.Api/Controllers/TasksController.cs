using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Application.TasksToDo.Create;
using TaskManager.Application.TasksToDo.Update;

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

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, TaskPutRequest request)
    {
        try
        {
            var validation = new TaskPutRequestValidator().Validate(request);
            var invalidRequest = !validation.IsValid;
            if (invalidRequest)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage));
            }
            request.Id = id;
            await mediator.Send((TaskUpdateRequest)request);

            return NoContent();
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