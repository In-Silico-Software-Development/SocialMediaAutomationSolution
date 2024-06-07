using Application.Features.Ads.Commands.Create;
using Application.Features.Ads.Commands.Delete;
using Application.Features.Ads.Commands.Update;
using Application.Features.Ads.Queries.GetById;
using Application.Features.Ads.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedAdResponse>> Add([FromBody] CreateAdCommand command)
    {
        CreatedAdResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedAdResponse>> Update([FromBody] UpdateAdCommand command)
    {
        UpdatedAdResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedAdResponse>> Delete([FromRoute] Guid id)
    {
        DeleteAdCommand command = new() { Id = id };

        DeletedAdResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdAdResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdAdQuery query = new() { Id = id };

        GetByIdAdResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListAdQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAdQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListAdListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}