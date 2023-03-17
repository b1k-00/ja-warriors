using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistence;
using Domain;

namespace Persistence.Repositories;

public class UserRepository : GenericRepository<User>
{
    private readonly JuniorAssociateDbContext _dbContext;

    public UserRepository(JuniorAssociateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}

