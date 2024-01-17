using Snap.Financials.Repositories;

namespace Snap.Financials.Infrastructure.Users;

public class UserRepository : IUserRepository
{
    public Guid GetCurrentUserId()
    {
        return Guid.Empty;
    }
}

