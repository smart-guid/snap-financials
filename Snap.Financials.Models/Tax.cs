namespace Snap.Financials.Models;

public class Tax
{
    public Guid Id { get; set; }

    public string Description { get; set; } = default!;
 
    public decimal Rate { get; set; }

    public string Province { get; set; } = default!;

    public string Country { get; set; } = default!;
}
