using Banking.Account.Domain.Model.Queries;
using Banking.Account.Domain.Services;
using Banking.Account.Interfaces.REST.Resources;
using Banking.Account.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Account.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[ProducesResponseType(400)]
[ProducesResponseType(500)]
public class AccountDetailsController(IAccountDetailCommandService accountDetailCommandService, IAccountDetailQueryService accountDetailQueryService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateAccountDetail([FromBody] CreateAccountDetailResource createAccountDetailResource)
    {
        var command = CreateAccountDetailCommandFromResourceAssembler.ToCommandFromResource(createAccountDetailResource);
        var account = await accountDetailCommandService.Handle(command);
        var accountResource = AccountDetailResourceFromEntityAssembler.ToResourceFromEntity(account);
        return StatusCode(201, accountResource);
    }
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetAllAccountDetails()
    {
        var query = new GetAllAccountsQuery();
        var accounts = await accountDetailQueryService.Handle(query);
        var accountResources = accounts.Select(AccountDetailResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(accountResources);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAccountDetailById(long id)
    {
        var query = new GetAccountByIdQuery(id);
        var account = await accountDetailQueryService.Handle(query);
        if (account is null)
        {
            return NotFound();
        }
        var accountResource = AccountDetailResourceFromEntityAssembler.ToResourceFromEntity(account);
        return Ok(accountResource);
    }
}