using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Application.Students.Create;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class StudentsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(StudentPostRequest request)
    {
        var result = await mediator.Send(new StudentCreateRequest());
        return Created("api/v1/students/{id}", new { id = result });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetSingle(Guid id)
    {
        var student = new StudentPostRequest
        {
            Id = id
        };
        return Ok(student);
    }
}