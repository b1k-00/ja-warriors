
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;
public interface IRegionApp
{
    Task<List<Region>> GetAllRegions();
    Task<string> CreateRegion(Region region);

    Task<Region> GetRegion(int id);

    Task<string> UpdateRegion(Region region);

    Task<string> DeleteRegion(int regionId);

}