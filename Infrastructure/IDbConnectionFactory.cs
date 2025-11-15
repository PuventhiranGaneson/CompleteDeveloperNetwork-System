using System.Data;

namespace CompleteDeveloperNetwork_System.Infrastructure
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
