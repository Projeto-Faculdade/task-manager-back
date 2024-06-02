using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Application.Extensions;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/v1/taskToDo")]
public class TaskController  : ControllerBase
{   
    [HttpPost]
    public async Task<IActionResult> Post(TaskItemPostRequest request)
    {

      
      await Task.Delay(100);

        return Created();

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

public class TaskToDoPostRequest
{
}