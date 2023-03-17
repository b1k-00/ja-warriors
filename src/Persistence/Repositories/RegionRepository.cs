using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class RegionRepository : GenericRepository<Region>
{
    private readonly JuniorAssociateDbContext _dbContext;

    public RegionRepository(JuniorAssociateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
