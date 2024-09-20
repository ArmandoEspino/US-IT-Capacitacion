using Microsoft.AspNetCore.Mvc;
using BankAPI.Services;
using BankAPI.Data.BankModels;
using Microsoft.AspNetCore.Authorization;

namespace BankAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BankTransactionController : ControllerBase
{

    private readonly BankTransactionService _service;
    
    public BankTransactionController(BankTransactionService bankTransaction)
    {   
        _service = bankTransaction;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<BankTransaction>> GetbyId(int id)
    {
        var account =  await _service.GetById(id);

        if(account is null)
            return AccountNotFound(id);

        return account;
    }


    [HttpPut("{id}/{type}/{amount}")]
    public async Task<IActionResult> Update( int id, int type, int amount, BankTransaction bankTransaction){

        if(id != bankTransaction.AccountId)
            return BadRequest();

        var accountToUpdate = await _service.GetById(id);

        if(accountToUpdate is not null)
        {
            await _service.Update(id, type, amount, bankTransaction);
            return NoContent();
        }
        else
        {
            return AccountNotFound(id);
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete( int id )
    {
        var accountToDelete = await _service.GetById(id);

        if(accountToDelete is not null)
        {
            if(accountToDelete.Amount == 0)
            {
                await _service.Delete(id);
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "La cuenta no esta en ceros"});
            }
        }
        else
        {
            return AccountNotFound(id);
        }
    }

    public NotFoundObjectResult AccountNotFound(int id)
    {
        return NotFound( new {message = $"El cliente con ID = {id} no existe"});
    }

}