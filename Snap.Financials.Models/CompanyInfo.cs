﻿namespace Snap.Financials.Models;

public class CompanyInfoModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public string Address { get; set; } = default!;

    public string City { get; set; } = default!;

    public string Province { get; set; } = default!;

    public string Country { get; set; } = default!;

    public string LogoUrl { get; set; } = default!;

    //public string TaxNumber { get; set; } = default!;
}

