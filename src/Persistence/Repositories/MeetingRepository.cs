﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;
public class MeetingRepository : GenericRepository<Meeting>
{
    private readonly JuniorAssociateDbContext _dbContext;

    public MeetingRepository(JuniorAssociateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
