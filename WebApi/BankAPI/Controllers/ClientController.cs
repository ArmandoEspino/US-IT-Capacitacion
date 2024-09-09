using Microsoft.AspNetCore.Mvc;
using BankAPI.Data;
using BankAPI.Data.BankModels;

namespace BankAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{

    private readonly BankContext _context;
    
    public ClientController(BankContext context)
    {   
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Client> Get()
    {
        return _context.Clients.ToList();
    }


    [HttpGet("{id}")]
    public ActionResult<Client> GetbyId(int id)
    {
        var client = _context.Clients.Find(id);

        if(client is null)
            return NotFound();

        return client;
    }


    [HttpPost]
    public IActionResult Create(Client client){
        _context.Clients.Add(client);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetbyId), new { id = client.Id } ,client);
    }


    [HttpPut("{id}")]
    public IActionResult Update( int id, Client client){

        if(id != client.Id)
            return BadRequest();

        var existingClient = _context.Clients.Find(id);

        if(existingClient is null)
            return NotFound();

        existingClient.Name = client.Name;
        existingClient.Email = client.Email;
        existingClient.PhoneNumber = client.PhoneNumber;

        _context.SaveChanges();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult Delete( int id )
    {
        var existingClient = _context.Clients.Find(id);
        if(existingClient is null)
            return NotFound();
        
        _context.Clients.Remove(existingClient);
        _context.SaveChanges();

        return Ok();
    }

}