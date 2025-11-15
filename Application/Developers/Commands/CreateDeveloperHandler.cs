using Dapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CompleteDeveloperNetwork_System.Application.Dto;
using CompleteDeveloperNetwork_System.Infrastructure;

public class CreateDeveloperHandler : IRequestHandler<CreateDeveloperCommand, DeveloperDto>
{
    private readonly IDbConnectionFactory _db;
    public CreateDeveloperHandler(IDbConnectionFactory db) => _db = db;

    public async Task<DeveloperDto> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
    {
        using var conn = _db.CreateConnection();
        await conn.OpenAsync(cancellationToken);
        using var tx = conn.BeginTransaction();

        var insertDevSql = @"
            INSERT INTO Developers (Username, Email, PhoneNumber, Udatetime, IsActive)
            VALUES (@Username, @Email, @PhoneNumber, GETUTCDATE(), 1);
            SELECT CAST(SCOPE_IDENTITY() AS int);
        ";

        var id = await conn.ExecuteScalarAsync<int>(insertDevSql, new { request.Username, request.Email, request.PhoneNumber }, tx);

        if (request.Skillsets != null && request.Skillsets.Any())
        {
            var skillParams = request.Skillsets.Select(s => new { DeveloperId = id, Name = s.Name });
            await conn.ExecuteAsync("INSERT INTO Skillsets (DeveloperId, Name) VALUES (@DeveloperId, @Name);", skillParams, tx);
        }

        if (request.Hobbies != null && request.Hobbies.Any())
        {
            var hobbyParams = request.Hobbies.Select(h => new { DeveloperId = id, Name = h.Name });
            await conn.ExecuteAsync("INSERT INTO Hobbies (DeveloperId, Name) VALUES (@DeveloperId, @Name);", hobbyParams, tx);
        }

        tx.Commit();

        return new DeveloperDto
        {
            Id = id,
            Username = request.Username,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Skillsets = request.Skillsets?.Select(s => s.Name).ToList() ?? new List<string>(),
            Hobbies = request.Hobbies?.Select(h => h.Name).ToList() ?? new List<string>(),
            Udatetime = DateTime.UtcNow,
            IsActive = 1
        };
    }
}
