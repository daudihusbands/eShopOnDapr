using NewApps.Application.Holdings;
using NewApps.Infrastructure.Persistence;

namespace NewApps.Infrastructure.Repositories;
public class HoldingRepository : Repository<Holding>, IHoldingRepository
{
    public HoldingRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
}
