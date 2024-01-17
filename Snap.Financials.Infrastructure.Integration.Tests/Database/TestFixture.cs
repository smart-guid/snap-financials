using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Snap.Financials.Infrastructure.Database;
using Snap.Financials.Infrastructure.Database.Mapping;
using Snap.Financials.Infrastructure.Users;

namespace Snap.Financials.Infrastructure.Integration.Tests.Database;

public class TestFixture : IDisposable
{
    public DatabaseContext Context { get; private set; } = default!;

    public IMapper Mapper { get; private set; } = default!;

    public SqlRepository Repository { get; private set; } = default!;

    public TestFixture()
    {
        this.Context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase($"IntegrationTest-{Guid.NewGuid()}").Options);

        this.Mapper = new MapperConfiguration(c =>
        {
            c.AddProfiles(new List<Profile>
            {
                new CompanyInfoMappingProfile(),
                new CustomerMappingProfile(),
                new InvoiceMappingProfile()
            });
        }).CreateMapper();

        var logger = new Mock<ILogger<SqlRepository>>().Object;

        var userRepository = new UserRepository();


        this.Repository = new SqlRepository(userRepository, this.Context, this.Mapper, logger);

        this.Context.Database.EnsureDeleted();
        this.Context.Database.EnsureCreated();
        this.Context.EnsureTestData();
    }

    public void Dispose()
    {
        this.Context.Dispose();
        this.Context = default!;
        GC.SuppressFinalize(this);
    }   
}

