using System.Net.Mime;
using Banking.Transfering.Domain.Model.Queries;
using Banking.Transfering.Domain.Services;
using Banking.Transfering.Interfaces.REST.Resources;
using Banking.Transfering.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Transfering.Interfaces.REST;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(400)]
[ProducesResponseType(500)]
public class TransactionsController(ITransactionCommandService transactionCommandService, ITransactionQueryService transactionQueryService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionResource createTransactionResource)
    {
        var command = CreateTransactionCommandFromResourceAssembler.ToCommandFromResource(createTransactionResource);
        var transaction = await transactionCommandService.Handle(command);
        var resource = TransactionResourceFromEntityAssembler.ToResourceFromEntity(transaction);
        return StatusCode(201, resource);

    }
    
    [HttpGet("totalBalance/{accountId}")]
    [ProducesResponseType(200)]
    public double GetTotalBalanceByAccountId(long accountId)
    {
        var query = new GetTotalBalanceByAccountIdQuery(accountId);
        return transactionQueryService.Handle(query);
    }
    
    [HttpGet("totalBalanceByYear/{accountId}/{year}")]
    [ProducesResponseType(200)]
    public double GetTotalBalanceByAccountIdAndYear(long accountId, int year)
    {
        var query = new GetTotalBalanceByAccountIdAndYearQuery(accountId, year);
        return transactionQueryService.Handle(query);
    }
    
      
    
}