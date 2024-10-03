using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleInterest.Data;
using PeopleInterest.Models;
using static PeopleInterest.Controllers.PeopleController;

namespace PeopleInterest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleInterestDbContext _context;

        public PeopleController(PeopleInterestDbContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> Index()
        {
            var person = await _context.Persons
                .Include(p => p.PersonInterests)
                .ThenInclude(pi => pi.Interest)
                .ThenInclude(i => i.InterestLinks)
                .ToListAsync();

            if (person == null || person.Count == 0)
            {
                return NotFound();
            }
            var personDTO = person.Select(p => new PersonDTO
            {
                Id = p.Id,
                Name = p.Name,
                PhoneNumber = p.PhoneNumber,
                Interests = p.PersonInterests.Select(pi => new InterestDTO
                {
                    Id = pi.InterestId,
                    Title = pi.Interest.Title,
                    Description = pi.Interest.Description,
                    Links = pi.Interest.InterestLinks.Select(il => new InterestLinkDTO
                    {
                        Id = il.Id,
                        Url = il.Url
                    }).ToList()
                }).ToList()
            }).ToList();
            return Ok(personDTO);
        }
        
        [HttpGet("GetPersonInterest/{id}")]
        public async Task<ActionResult<InterestDTO>> GetPersonInterest(int id)
        {
            var personInterest = await _context.PersonInterests
                .Where(pi => pi.PersonId == id)
                .Include(pi => pi.Interest)
                .ThenInclude(i => i.InterestLinks)
                .Select(pi => new InterestDTO
                {
                    Id = pi.InterestId,
                    Title = pi.Interest.Title,
                    Description = pi.Interest.Description,
                    Links = pi.Interest.InterestLinks.Select(il => new InterestLinkDTO
                    {
                        Id = il.Id,
                        Url = il.Url
                    }).ToList()
                }).ToListAsync();

           
            if (personInterest == null)
            {
                return NotFound();
            }

            return Ok(personInterest);
        }

        [HttpGet("GetPersonInterestLink/{personId}")]
        public async Task<ActionResult<InterestLinkDTO>> GetPersonInterestLink(int personId)
        {
            var personLinks = await _context.PersonInterests
                .Where(pi => pi.PersonId == personId)
                .Include(pi => pi.Interest)
                    .ThenInclude(i => i.InterestLinks)
                .SelectMany(pi => pi.Interest.InterestLinks)
                .Select(link => new InterestLinkDTO
                {
                    Id = link.Id,
                    Url = link.Url
                }).ToListAsync();

            if (personLinks == null || personLinks.Count == 0)
            {
                return NotFound();
            }
            return Ok(personLinks);
        }

        
        [HttpPost("AddInterestToPerson/{id}")]
        public async Task<ActionResult> AddInterestToPerson(int id, [FromBody] InterestDTO interestDTO)
        {
            if (interestDTO == null)
            {
                return BadRequest("Interest cannot be null.");
            }

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound("No Person With Specified Id Exists");
            }

            var interest = new Interest { Description = interestDTO.Description, Title = interestDTO.Title };
            _context.Add(interest);
            await _context.SaveChangesAsync();

            var personInterest = new PersonInterest { PersonId = id, InterestId = interest.Id };
            _context.PersonInterests.Add(personInterest);
            await _context.SaveChangesAsync();

            return Ok($"Person {id} added interest {interestDTO.Title} successfully!");
        }
        [HttpPost("AddLinksToPersonAndInterest/{personId}/{interestId}")]
        public async Task<ActionResult> AddLinksToPersonAndInterest(int personId, int interestId, [FromBody] InterestLinkDTO interestLinkDTO)
        {

            if (interestLinkDTO == null)
            {
                return BadRequest("Link cannot be null.");
            }
            var person = await _context.Persons.FindAsync(personId);
            if (person == null)
            {
                return NotFound("No Person With Specified Id Exists");
            }
            var interest = await _context.Interests.FindAsync(interestId);
            if (interest == null)
            {
                return NotFound("No Interest With Specified Id Exists");
            }
            var interestLink = new InterestLink
            {
                InterestId = interest.Id,
                Url = interestLinkDTO.Url
            };
            _context.Add(interestLink);
            await _context.SaveChangesAsync();
            interest.InterestLinks.Add(interestLink);
            await _context.SaveChangesAsync();
            return Ok($"Person {personId} With Interest {interestId} Added Url {interestLinkDTO.Url}");
        }

    }
}
