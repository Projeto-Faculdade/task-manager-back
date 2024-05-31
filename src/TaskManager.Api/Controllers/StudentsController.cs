using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class StudentsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(StudentPostRequest request)
    {
        return Created("api/v1/students/{id}", new { request.Id });
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