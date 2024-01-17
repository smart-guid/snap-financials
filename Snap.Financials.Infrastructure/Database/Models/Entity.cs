namespace Snap.Financials.Infrastructure.Database.Models;

public abstract class Entity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }
}