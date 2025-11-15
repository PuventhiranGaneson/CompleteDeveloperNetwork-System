using Dapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CompleteDeveloperNetwork_System.Application.Dto;
using CompleteDeveloperNetwork_System.Infrastructure;

public class GetDevelopersHandler : IRequestHandler<GetDevelopersQuery, IEnumerable<DeveloperDto>>
{
    private readonly IDbConnectionFactory _db;
    public GetDevelopersHandler(IDbConnectionFactory db) => _db = db;

    public async Task<IEnumerable<DeveloperDto>> Handle(GetDevelopersQuery request, CancellationToken cancellationToken)
    {
        using var conn = _db.CreateConnection();

        var sql = @"
        SELECT d.Id, d.Username, d.Email, d.PhoneNumber, d.UDateTime, d.IsActive,
               s.Name AS Skill, h.Name AS Hobby
        FROM Developers d
        LEFT JOIN DeveloperSkills ds ON d.Id = ds.DeveloperId
        LEFT JOIN Skills s ON ds.SkillId = s.Id
        LEFT JOIN DeveloperHobbies dh ON d.Id = dh.DeveloperId
        LEFT JOIN Hobbies h ON dh.HobbyId = h.Id
        WHERE (@Search IS NULL OR d.Username LIKE '%' + @Search + '%' OR d.Email LIKE '%' + @Search + '%')
        ORDER BY d.Id
        OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY;";

        var devs = (await conn.QueryAsync<DeveloperDto>(sql, new { Search = request.Search, Skip = request.Skip, Take = request.Take })).ToList();

        if (!devs.Any()) return devs;

        var ids = devs.Select(d => d.Id).ToArray();

        // fetch skillsets
        var skillsSql = "SELECT DeveloperId, Name FROM Skillsets WHERE DeveloperId IN @Ids;";
        var skillRows = await conn.QueryAsync<(int DeveloperId, string Name)>(skillsSql, new { Ids = ids });

        // fetch hobbies
        var hobbiesSql = "SELECT DeveloperId, Name FROM Hobbies WHERE DeveloperId IN @Ids;";
        var hobbyRows = await conn.QueryAsync<(int DeveloperId, string Name)>(hobbiesSql, new { Ids = ids });

        var skillLookup = skillRows.GroupBy(s => s.DeveloperId).ToDictionary(g => g.Key, g => g.Select(x => x.Name).ToList());
        var hobbyLookup = hobbyRows.GroupBy(h => h.DeveloperId).ToDictionary(g => g.Key, g => g.Select(x => x.Name).ToList());

        foreach (var d in devs)
        {
            skillLookup.TryGetValue(d.Id, out var s); if (s != null) d.Skillsets = s;
            hobbyLookup.TryGetValue(d.Id, out var h); if (h != null) d.Hobbies = h;
        }

        return devs;
    }
}
