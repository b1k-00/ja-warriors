using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistence;
using Domain;

namespace Persistence.Repositories;

public class UserAvailabilityRepository : GenericRepository<UserAvailability>
{
    private readonly JuniorAssociateDbContext _dbContext;

    public UserAvailabilityRepository(JuniorAssociateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}

