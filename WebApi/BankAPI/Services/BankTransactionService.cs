using Microsoft.EntityFrameworkCore;
using BankAPI.Data.BankModels;
using BankAPI.Data;

namespace BankAPI.Services;

public class BankTransactionService
{
    private readonly BankContext _context;

    public BankTransactionService( BankContext context )
    {
        _context = context;
    }


    public async Task<BankTransaction?> GetById( int id )
    {
        var account = await _context.Accounts.FindAsync(id);

        var idBank = account!.Id;

        return await _context.BankTransactions.FindAsync(idBank);
    }



    public async Task Update(int id, int type, int amount, BankTransaction bankTransaction)
    {
        var existingAccount = await GetById(id);

        if (existingAccount is not null)
        {
            if(type == 1)   // Deposito
            {
                existingAccount.Amount += amount;
                existingAccount.Amount = bankTransaction.Amount;
            }
            else    // Retiro
            {
                existingAccount.Amount -= amount;
                existingAccount.Amount = bankTransaction.Amount;
            }

            await _context.SaveChangesAsync();
        }

    }

    public async Task Delete(int id)
    {
        var accountToDelete = await GetById(id);

        if(accountToDelete is not null)
        {
            _context.BankTransactions.Remove(accountToDelete);
            await _context.SaveChangesAsync();
        }


    }

}