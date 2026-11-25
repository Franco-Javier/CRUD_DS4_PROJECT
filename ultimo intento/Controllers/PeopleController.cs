namespace ultimo_intento.Controllers;
using ultimo_intento.Data;
using ultimo_intento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly AppDbContext _context;

    public PeopleController(AppDbContext context)
    {
        _context = context;
    }

    // READ (Todos ordenados por Id usando LINQ)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
    {
        var lista = await _context.People
            .OrderBy(p => p.Id)
            .ToListAsync();
        return Ok(lista);
    }

    // CREATE
    [HttpPost]
    public async Task<ActionResult<Person>> CreatePerson([FromBody] Person person)
    {
        _context.People.Add(person);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPeople), new { id = person.Id }, person);
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePerson(int id, [FromBody] Person person)
    {
        if (id != person.Id) return BadRequest("El ID no coincide.");

        var existente = await _context.People.FirstOrDefaultAsync(p => p.Id == id);
        if (existente == null) return NotFound();

        existente.Name = person.Name;
        existente.Age = person.Age;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(int id)
    {
        var persona = await _context.People.FirstOrDefaultAsync(p => p.Id == id);
        if (persona == null) return NotFound();

        _context.People.Remove(persona);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

