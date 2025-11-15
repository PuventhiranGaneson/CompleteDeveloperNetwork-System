using Microsoft.AspNetCore.Mvc;
using MediatR;
using CompleteDeveloperNetwork_System.Application.Developers.Queries;
using CompleteDeveloperNetwork_System.Application.Developers.Commands;
using CompleteDeveloperNetwork_System.Application.Dto;

[ApiController]
[Route("api/[controller]")]
public class DevelopersController : ControllerBase
{
    private readonly IMediator _mediator;
    public DevelopersController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? search, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var q = new GetDevelopersQuery { Search = search, PageNumber = pageNumber, PageSize = pageSize };
        var res = await _mediator.Send(q);
        return Ok(res);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var res = await _mediator.Send(new GetDeveloperByIdQuery(id));
        return res == null ? NotFound() : Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDeveloperCommand cmd)
    {
        var created = await _mediator.Send(cmd);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDeveloperCommand cmd)
    {
        cmd.Id = id;
        var updated = await _mediator.Send(cmd);
        return Ok(updated);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, [FromBody] PatchDeveloperCommand cmd)
    {
        cmd.Id = id;
        var patched = await _mediator.Send(cmd);
        return Ok(patched);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteDeveloperCommand(id));
        return NoContent();
    }
}
