using CompleteDeveloperNetwork_System.Data;
using CompleteDeveloperNetwork_System.Dto;
using CompleteDeveloperNetwork_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompleteDeveloperNetwork_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevelopersController : ControllerBase
    {
        private readonly DataContext _context;

        public DevelopersController(DataContext context)
        {
            _context = context;
        }

        // ✅ GET all developers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeveloperDto>>> GetDevelopers()
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


        //GET developer by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Developers>> GetDeveloper(int id)
        {
            var dev = await _context.developers
                                    .Include(d => d.skillsets)
                                    .Include(d => d.hobbies)
                                    .FirstOrDefaultAsync(d => d.Id == id);


            if (dev == null)
                return NotFound();

            var devDto = new DeveloperDto
            {
                Id = dev.Id,
                Username = dev.Username,
                Email = dev.Email,
                PhoneNumber = dev.PhoneNumber,
                Skillsets = dev.skillsets.Select(s => s.Name).ToList(),
                Hobbies = dev.hobbies.Select(h => h.Name).ToList()
            };

            return Ok(devDto);
        }

        [HttpPost]
        public async Task<ActionResult<DeveloperDto>> CreateDeveloper(CreateDeveloperDto dto)
        {
            // Create developer
            var developer = new Developers
            {
                Username = dto.Username,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber, // or keep as string if you changed it
                skillsets = dto.Skillsets?.Select(s => new Skillsets
                {
                    Name = s.Name,
                    Description = s.Description
                }).ToList(),
                hobbies = dto.Hobbies?.Select(h => new Hobbies
                {
                    Name = h.Name,
                    Description = h.Description
                }).ToList()
            };

            _context.developers.Add(developer);
            await _context.SaveChangesAsync();

            // Map back to DTO for response
            var devDto = new DeveloperDto
            {
                Id = developer.Id,
                Username = developer.Username,
                Email = developer.Email,
                PhoneNumber = developer.PhoneNumber.ToString(),
                Skillsets = developer.skillsets.Select(s => s.Name).ToList(),
                Hobbies = developer.hobbies.Select(h => h.Name).ToList()
            };

            return CreatedAtAction(nameof(GetDeveloper), new { id = developer.Id }, devDto);
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
                Hobbies = developer.hobbies.Select(h => h.Name).ToList()
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
