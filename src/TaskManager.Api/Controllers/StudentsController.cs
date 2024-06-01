using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/v1/students")]
public class StudentsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(StudentPostRequest request)
    {
        var result = await mediator.Send(request);
        return Created("api/v1/students/{id}", new { id = result });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, StudentPutRequest request)
    {
        request.Id = id;
        await mediator.Send(request);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents([FromHeader(Name = "Accept-Language")] string preferredLanguage)
    {
        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetSingle(Guid id, [FromHeader(Name = "Accept-Language")] string preferredLanguage)
    {
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        return NoContent();
    }
}