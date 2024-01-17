using AutoMapper;

namespace Snap.Financials.Infrastructure.Integration.Tests.Database;

public class MappingTests(TestFixture fixture)
{
    private readonly IMapper mapper = fixture.Mapper;

    [Fact]
    public void ShouldHaveValidMappingConfiguration()
    {
        this.mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }
}

