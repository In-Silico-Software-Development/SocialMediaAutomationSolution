using Application.Features.SocialMediaAccounts.Commands.Create;
using Application.Features.SocialMediaAccounts.Commands.Delete;
using Application.Features.SocialMediaAccounts.Commands.Update;
using Application.Features.SocialMediaAccounts.Queries.GetById;
using Application.Features.SocialMediaAccounts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialMediaAccountsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSocialMediaAccountResponse>> Add([FromBody] CreateSocialMediaAccountCommand command)
    {
        CreatedSocialMediaAccountResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSocialMediaAccountResponse>> Update([FromBody] UpdateSocialMediaAccountCommand command)
    {
        UpdatedSocialMediaAccountResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSocialMediaAccountResponse>> Delete([FromRoute] Guid id)
    {
        DeleteSocialMediaAccountCommand command = new() { Id = id };

        DeletedSocialMediaAccountResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSocialMediaAccountResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdSocialMediaAccountQuery query = new() { Id = id };

        GetByIdSocialMediaAccountResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSocialMediaAccountQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSocialMediaAccountQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSocialMediaAccountListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}