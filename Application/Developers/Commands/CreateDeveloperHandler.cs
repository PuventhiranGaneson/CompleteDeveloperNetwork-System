using CompleteDeveloperNetwork_System.Data;
using CompleteDeveloperNetwork_System.Dto;
using CompleteDeveloperNetwork_System.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class CreateDeveloperHandler : IRequestHandler<CreateDeveloperCommand, DeveloperDto>
{
    private readonly DataContext _context;

    public CreateDeveloperHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<DeveloperDto> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
    {
        var developer = new Developers
        {
            Username = request.Username,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Udatetime = DateTime.Now,
            IsActive = 1,
            skillsets = request.Skillsets?.Select(s => new Skillsets
            {
                Name = s.Name,
                Description = s.Description
            }).ToList(),
            hobbies = request.Hobbies?.Select(h => new Hobbies
            {
                Name = h.Name,
                Description = h.Description
            }).ToList()
        };

        _context.developers.Add(developer);
        await _context.SaveChangesAsync(cancellationToken);

        return new DeveloperDto
        {
            Id = developer.Id,
            Username = developer.Username,
            Email = developer.Email,
            PhoneNumber = developer.PhoneNumber,
            Skillsets = developer.skillsets.Select(s => s.Name).ToList(),
            Hobbies = developer.hobbies.Select(h => h.Name).ToList(),
            Udatetime = developer.Udatetime,
            IsActive = developer.IsActive
        };
    }
}
