using BankAPI.Data;
using BankAPI.Data.BankModels;
using BankAPI.Data.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace TestBankAPI.Services;

public class ClientAuthenticateService
{
    private readonly BankContext _context;

    public ClientAuthenticateService(BankContext context)
    {
        _context = context;
    }

    public async Task<Client?> GetClientAut(ClientDto client)
    {
        return await _context.Clients.SingleOrDefaultAsync(x => x.Email == client.Email && x.Pwd == client.Pwd);
    }
}