using MediatR;
using CompleteDeveloperNetwork_System.Dto;
using System.Collections.Generic;

namespace CompleteDeveloperNetwork_System.CQRS.Commands
{
    // Command: request to create a new developer
    public record CreateDeveloperCommand(
        string Username,
        string Email,
        string PhoneNumber,
        List<SkillsetDto> Skillsets,
        List<HobbyDto> Hobbies
    ) : IRequest<DeveloperDto>;

    // Helper DTOs for skillsets and hobbies input
    public class SkillsetDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class HobbyDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}