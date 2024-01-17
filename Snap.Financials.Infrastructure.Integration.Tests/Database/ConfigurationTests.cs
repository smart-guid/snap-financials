using Microsoft.EntityFrameworkCore;

namespace Snap.Financials.Infrastructure.Integration.Tests.Database;

public class ConfigurationTests(TestFixture fixture)
{
    [Fact]
    public void Database_ShouldBe_Configured()
    {
        // Arrange
        var context = fixture.Context;

        // Assert
        Assert.True(context.Database.IsInMemory());     
    }
}
