namespace Snap.Financials.Infrastructure.Database.Models;

public class CompanyInfo : Entity
{
    public string Name { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public string Address { get; set; } = default!;

    public string City { get; set; } = default!;

    public string Province { get; set; } = default!;

    public string Country { get; set; } = default!;

    public string LogoUrl { get; set; } = default!;
}