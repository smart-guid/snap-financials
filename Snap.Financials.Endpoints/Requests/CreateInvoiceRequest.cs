namespace Snap.Financials.Endpoints.Requests;

public class CreateInvoiceRequest
{
    public Guid CustomerId { get; set; }

    public string InvoiceNumber { get; set; } = default!;

    public DateTime InvoiceDate { get; set; }
    public DateTime DueDate { get; set; }

    public string PaymentTerms { get; set; } = default!;
    public string PaymentInstructions { get; set; } = default!;
}
