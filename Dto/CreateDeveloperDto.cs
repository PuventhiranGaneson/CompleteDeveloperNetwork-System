using CompleteDeveloperNetwork_System.Dto;
using MediatR;
using System.Collections.Generic;

public record CreateDeveloperCommand(
    string Username,
    string Email,
    string PhoneNumber,
    List<SkillsetDto> Skillsets,
    List<HobbyDto> Hobbies
) : IRequest<DeveloperDto>;

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
