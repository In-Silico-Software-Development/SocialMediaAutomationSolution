using Application.Features.AdPerformances.Commands.Create;
using Application.Features.AdPerformances.Commands.Delete;
using Application.Features.AdPerformances.Commands.Update;
using Application.Features.AdPerformances.Queries.GetById;
using Application.Features.AdPerformances.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdPerformancesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedAdPerformanceResponse>> Add([FromBody] CreateAdPerformanceCommand command)
    {
        CreatedAdPerformanceResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedAdPerformanceResponse>> Update([FromBody] UpdateAdPerformanceCommand command)
    {
        UpdatedAdPerformanceResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedAdPerformanceResponse>> Delete([FromRoute] Guid id)
    {
        DeleteAdPerformanceCommand command = new() { Id = id };

        DeletedAdPerformanceResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdAdPerformanceResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdAdPerformanceQuery query = new() { Id = id };

        GetByIdAdPerformanceResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListAdPerformanceQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAdPerformanceQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListAdPerformanceListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}