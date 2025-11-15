using CompleteDeveloperNetwork_System.Application.Dto;
using MediatR;
using System.Collections.Generic;

namespace CompleteDeveloperNetwork_System.Application.Developers.Commands
{
    // Command: carries the data from the request into the Handler
    public record CreateDeveloperCommand(
        string Username,
        string Email,
        string PhoneNumber,
        List<SkillsetDto> Skillsets,
        List<HobbyDto> Hobbies
    ) : IRequest<DeveloperDto>;
}
