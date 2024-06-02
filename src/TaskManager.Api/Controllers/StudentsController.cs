﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Application.Students.Create;
using TaskManager.Application.Students.Delete;
using TaskManager.Application.Students.GetAll;
using TaskManager.Application.Students.GetById;
using TaskManager.Application.Students.Update;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/v1/students")]
public class StudentsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(StudentPostRequest request)
    {
        try
        {
            var validation = new StudentPostRequestValidator().Validate(request);
            var invalidRequest = !validation.IsValid;
            if (invalidRequest)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage));
            }
            var result = await mediator.Send((StudentCreateRequest)request);
            return Created("api/v1/tudentss/id", new { id = result });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, StudentPutRequest request)
    {
        try
        {
            var validation = new StudentPutRequestValidator().Validate(request);
            var invalidRequest = !validation.IsValid;
            if (invalidRequest)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage));
            }
            request.Id = id;
            await mediator.Send((StudentUpdateRequest)request);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents([FromHeader(Name = "Accept-Language")] string preferredLanguage)
    {
        var request = new StudentGetAllRequest
        {
            PreferredLanguage = preferredLanguage
        };
        var result = await mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetSingle(Guid id, [FromHeader(Name = "Accept-Language")] string preferredLanguage)
    {
        var request = new StudentGetByIdRequest
        {
            Id = id,
            PreferredLanguage = preferredLanguage
        };

        var result = await mediator.Send(request);

        if (result == default)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        var request = new StudentDeleteRequest
        {
            Id = id,
        };
        await mediator.Send(request);

        return NoContent();
    }
}