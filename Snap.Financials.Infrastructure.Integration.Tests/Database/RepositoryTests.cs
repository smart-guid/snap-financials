namespace Snap.Financials.Infrastructure.Integration.Tests.Database;

public class RepositoryTests(TestFixture fixture)
{
    #region Company Info

    [Fact]
    public async void GetCompanyInfo_Returns_CompanyInfo()
    {
        // Arrange
        var repository = fixture.Repository;
        var token = new CancellationTokenSource().Token;

        // Act
        var result = await repository.GetCompanyInfoAsync(token);

        // Assert
        Assert.NotNull(result);
    }

    #endregion

    #region Customers

    #endregion

    #region Invoices  


    #endregion
}
