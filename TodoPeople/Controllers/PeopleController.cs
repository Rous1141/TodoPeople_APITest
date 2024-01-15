using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoPeople.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoPeople.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly DatabaseContext? _context;

        public PeopleController(DatabaseContext context)
        {
            _context = context;
        }

        //get all People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeopleDTO>>> GetAllPeople()
        {
            return await _context.People.ToListAsync();
        }

        //get a People by id
        [HttpGet("{id}")]
        public async Task<ActionResult<PeopleDTO>> GetPeopleById(int id)
        {
            var people = await _context.People.FindAsync(id);
            if (people == null)
            {
                return NotFound();
            }
            return people;
        }

        //insert new People
        [HttpPost]
        public async Task<ActionResult<PeopleDTO>> PostPeole(PeopleDTO people)
        {
            _context.People.Add(people);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeopleById", new { id = people.Id }, people);
        }

        //update a People
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeople(int id, PeopleDTO people)
        {
            if(id != people.Id)
            {
                return BadRequest();
            }

            _context.Entry(people).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException)
            {
                if (!PeoleExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        //delete a People
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePeole(int id)
        {
            var people = await _context.People.FindAsync(id);
            if (people == null)
            {
                return NotFound();
            }
            else
            {
                _context.People.Remove(people);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }
        private bool PeoleExist(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}

