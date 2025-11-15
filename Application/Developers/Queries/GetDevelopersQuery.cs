using MediatR;
using System.Collections.Generic;
using CompleteDeveloperNetwork_System.Application.Dto;

public class GetDevelopersQuery : IRequest<IEnumerable<DeveloperDto>>
{
    public string? Search { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int Skip => (PageNumber - 1) * PageSize;
    public int Take => PageSize;
}
