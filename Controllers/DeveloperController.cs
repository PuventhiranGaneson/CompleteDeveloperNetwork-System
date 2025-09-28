using CompleteDeveloperNetwork_System.Data;
using CompleteDeveloperNetwork_System.Dto;
using CompleteDeveloperNetwork_System.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompleteDeveloperNetwork_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevelopersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMediator _mediator;
        public DevelopersController(DataContext context)
        {
            _context = context;
        }

        // ✅ GET all developers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeveloperDto>>> GetDeveloper()
        {
            var devs = await _context.developers
                .Include(d => d.skillsets)
                .Include(d => d.hobbies)
                .Select(d => new DeveloperDto
                {
                    Id = d.Id,
                    Username = d.Username,
                    Email = d.Email,
                    Skillsets = d.skillsets.Select(s => s.Name).ToList(),
                    Hobbies = d.hobbies.Select(h => h.Name).ToList()
                })
                .ToListAsync();

            return Ok(devs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeveloperDto>> GetDeveloperById(int id)
        {
            var dev = await _context.developers
                .Include(d => d.skillsets)
                .Include(d => d.hobbies)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dev == null)
                return NotFound();

            return Ok(new DeveloperDto
            {
                Id = dev.Id,
                Username = dev.Username,
                Email = dev.Email,
                Skillsets = dev.skillsets.Select(s => s.Name).ToList(),
                Hobbies = dev.hobbies.Select(h => h.Name).ToList()
            });
        }



        // GET api/developers/search?username=abc&email=xyz
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<DeveloperDto>>> SearchDevelopers(
            [FromQuery] string? username,
            [FromQuery] string? email)
        {
            var query = _context.developers
                .Include(d => d.skillsets)
                .Include(d => d.hobbies)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(username))
                query = query.Where(d => d.Username.Contains(username));

            if (!string.IsNullOrWhiteSpace(email))
                query = query.Where(d => d.Email.Contains(email));

            var devs = await query.Select(dev => new DeveloperDto
            {
                Username = dev.Username,
                Email = dev.Email,
                PhoneNumber = dev.PhoneNumber,
                Skillsets = dev.skillsets.Select(s => s.Name).ToList(),
                Hobbies = dev.hobbies.Select(h => h.Name).ToList()
            }).ToListAsync();

            if (!devs.Any())
                return NotFound("No matching developers found.");

            return Ok(devs);
        }


        [HttpPost]
        public async Task<ActionResult<DeveloperDto>> CreateDeveloper([FromBody] CreateDeveloperCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDeveloper), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DeveloperDto>> UpdateDeveloper(int id, UpdateDeveloperDto dto)
        {
            var developer = await _context.developers
                .Include(d => d.skillsets)
                .Include(d => d.hobbies)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (developer == null)
                return NotFound();

            // Update basic fields
            developer.Username = dto.Username;
            developer.Email = dto.Email;
            developer.PhoneNumber = dto.PhoneNumber;
            developer.Udatetime = DateTime.Now;

            // Clear and re-add skillsets
            developer.skillsets.Clear();
            developer.skillsets = dto.Skillsets?.Select(s => new Skillsets
            {
                Name = s.Name,
                Description = s.Description,
                DeveloperId = id
            }).ToList();

            // Clear and re-add hobbies
            developer.hobbies.Clear();
            developer.hobbies = dto.Hobbies?.Select(h => new Hobbies
            {
                Name = h.Name,
                Description = h.Description,
                DeveloperId = id
            }).ToList();

            await _context.SaveChangesAsync();

            // Return updated DTO
            var devDto = new DeveloperDto
            {
                Id = developer.Id,
                Username = developer.Username,
                Email = developer.Email,
                PhoneNumber = developer.PhoneNumber.ToString(),
                Skillsets = developer.skillsets.Select(s => s.Name).ToList(),
                Udatetime = developer.Udatetime
            };

            return Ok(devDto);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<DeveloperDto>> PatchDeveloper(int id, PatchDeveloperDto dto)
        {
            var developer = await _context.developers
                .Include(d => d.skillsets)
                .Include(d => d.hobbies)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (developer == null)
                return NotFound();

            // Update only if values are provided
            if (!string.IsNullOrEmpty(dto.Username))
                developer.Username = dto.Username;

            if (!string.IsNullOrEmpty(dto.Email))
                developer.Email = dto.Email;

            if (!string.IsNullOrEmpty(dto.PhoneNumber))
                developer.PhoneNumber = dto.PhoneNumber;

            if (dto.Skillsets != null)
            {
                developer.skillsets.Clear();
                developer.skillsets = dto.Skillsets.Select(s => new Skillsets
                {
                    Name = s.Name,
                    Description = s.Description,
                    DeveloperId = id
                }).ToList();
            }

            if (dto.Hobbies != null)
            {
                developer.hobbies.Clear();
                developer.hobbies = dto.Hobbies.Select(h => new Hobbies
                {
                    Name = h.Name,
                    Description = h.Description,
                    DeveloperId = id
                }).ToList();
            }

            await _context.SaveChangesAsync();

            // Return updated developer DTO
            var devDto = new DeveloperDto
            {
                Id = developer.Id,
                Username = developer.Username,
                Email = developer.Email,
                PhoneNumber = developer.PhoneNumber.ToString(),
                Skillsets = developer.skillsets.Select(s => s.Name).ToList(),
                Hobbies = developer.hobbies.Select(h => h.Name).ToList()
            };

            return Ok(devDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeveloper(int id)
        {
            var developer = await _context.developers
                .Include(d => d.skillsets)
                .Include(d => d.hobbies)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (developer == null)
                return NotFound();

            // EF Core will handle cascade delete if configured in your model.
            _context.developers.Remove(developer);
            await _context.SaveChangesAsync();

            return NoContent(); // 204 No Content
        }

    }
}
