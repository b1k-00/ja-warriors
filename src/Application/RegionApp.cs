using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Persistence;
using Domain;

namespace Application;
public class RegionApp : AppBase<Region>, IRegionApp, IApp<Region>
{
    public IGenericRepository<Region> _regionRepo { get; set; }

    public RegionApp(IGenericRepository<Region> regionRepo) : base(regionRepo)
    {
        _regionRepo = regionRepo;
    }

}