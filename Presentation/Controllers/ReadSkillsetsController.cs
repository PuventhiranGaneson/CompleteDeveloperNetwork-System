using CompleteDeveloperNetwork_System.Application.Dto;
using CompleteDeveloperNetwork_System.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompleteDeveloperNetwork_System.Infrastructure.Data;

namespace CompleteDeveloperNetwork_System.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadSkillsetsController : ControllerBase
    {
        private readonly DataContext _context;

        public ReadSkillsetsController(DataContext context)
        {
            _context = context;
        }

        //GET all skillsets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillsetsDto>>> GetSkillsets()
        {

            var devs = await _context.Skillsets
                .Select(s => new SkillsetsDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    DeveloperId = s.DeveloperId,
                })
                .ToListAsync();

            return Ok(devs);
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<IEnumerable<SkillsetsDto>>> GetSkillsets(int id)
        {

            var skill = await _context.Skillsets
                .FirstOrDefaultAsync(d => d.Id == id);

            if (skill == null)
                return NotFound();

            var skillDto = new SkillsetsDto
            {
                Id = skill.Id,
                Name = skill.Name,
                Description = skill.Description,
                DeveloperId = skill.DeveloperId,

            };

            return Ok(skillDto);
        }


    }
}
