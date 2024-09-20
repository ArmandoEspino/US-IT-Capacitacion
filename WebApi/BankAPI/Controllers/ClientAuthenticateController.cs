using Microsoft.AspNetCore.Mvc;
using BankAPI.Services;
using BankAPI.Data.DTOs;
using TestBankAPI.Services;

using BankAPI.Data.BankModels;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BankAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientAuthenticateController : ControllerBase
{
    private readonly ClientAuthenticateService clientAuthenticateService;

    private IConfiguration config;

    public ClientAuthenticateController(ClientAuthenticateService clientAuthenticateService, IConfiguration config)
    {
        this.clientAuthenticateService = clientAuthenticateService;
        this.config = config;
    }

    [HttpPost("Autenticat")]

    public async Task<IActionResult> Login(ClientDto clientDto)
    {
        var clien = await clientAuthenticateService.GetClientAut(clientDto);

        if(clien is null)
            return BadRequest(new {message = "Credenciales invalidas."});

        string jwtToken = GenerateToken(clien);

        return Ok( new { token = jwtToken } );
    }


    private string GenerateToken(Client clien)
    {
        var claims = new []
        {
            new Claim(ClaimTypes.Name, clien.Name),
            new Claim(ClaimTypes.Email, clien.Email!)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("JWT:Key").Value!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var securityToken = new JwtSecurityToken(
                            claims: claims,
                            expires: DateTime.Now.AddMinutes(60),
                            signingCredentials: creds);

        string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return token;
    }

}