using CompleteDeveloperNetwork_System.Data;
using CompleteDeveloperNetwork_System.Dto;
using CompleteDeveloperNetwork_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompleteDeveloperNetwork_System.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class ReadHobbiesController : ControllerBase
        {
            private readonly DataContext _context;

            public ReadHobbiesController(DataContext context)
            {
                _context = context;
            }

            //GET all skillsets
            [HttpGet]
            public async Task<ActionResult<IEnumerable<HobbiesDto>>> GetHobbies()
            {

            var hobbies = await _context.Hobbies
                        .Select(s => new HobbiesDto
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Description = s.Description,
                            DeveloperId = s.DeveloperId,
                        })
                        .ToListAsync();

            return Ok(hobbies);
        }

            [HttpGet("{id}")]

            public async Task<ActionResult<IEnumerable<HobbiesDto>>> GetHobbies(int id)
            {

                var hobbies = await _context.Skillsets
                    .FirstOrDefaultAsync(d => d.Id == id);

                if (hobbies == null)
                    return NotFound();

                var HobbiesDto = new HobbiesDto
                {
                    Id = hobbies.Id,
                    Name = hobbies.Name,
                    Description = hobbies.Description,
                    DeveloperId = hobbies.DeveloperId,

                };

                return Ok(HobbiesDto);
            }


        }
    
}
