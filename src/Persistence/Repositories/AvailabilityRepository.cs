using Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;
public class AvailabilityRepository : GenericRepository<Availability>
{
    private readonly JuniorAssociateDbContext _dbContext;

    public AvailabilityRepository(JuniorAssociateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
