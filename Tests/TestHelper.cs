using Microsoft.EntityFrameworkCore;
using CompleteDeveloperNetwork_System.Data;

public static class TestHelper
{
    public static DataContext GetInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "TestDb_" + Guid.NewGuid())
            .Options;

        return new DataContext(options);
    }
}
