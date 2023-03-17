using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;
public class DesignStudioRepository : GenericRepository<DesignStudio>
{
    private readonly JuniorAssociateDbContext _dbContext;

    public DesignStudioRepository(JuniorAssociateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
