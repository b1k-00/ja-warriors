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
public class RegionApp : IRegionApp
{
    public IGenericRepository<Region> _regionRepo { get; set; }

    public RegionApp(IGenericRepository<Region> regionRepo)
    {
        _regionRepo = regionRepo;
    }


    public async Task<List<Region>> GetAllRegions()
    {
        List<Region> result = new List<Region>();
        try
        {
            result = (await _regionRepo.GetAllAsync()).ToList<Region>();
        }
        catch (Exception ex)
        {
           result = new List<Region>();
        }

        return result;
    }

    public async Task<Region> GetRegion(int id)
    {
        var region = await _regionRepo.GetAsync(id);
        return region;
    }

    public async Task<string> CreateRegion(Region region)
    {
        var regions = await _regionRepo.GetAllAsync();
        var result = "Unable to add!";

        if (!regions.Select(x => x.Name).Contains(region.Name))
            {
            await _regionRepo.AddAsync(region);
            result = "Successfully Added!";
        }
        return result;

    }

    public async Task<string> UpdateRegion(Region region)
    {
        var result = "Updated Successfully";
        try
        {

            await _regionRepo.UpdateAsync(region);
        }

        catch (Exception ex)
        {
            result = "Update Failed";
        }

        return result;

    }
    public async Task<string> DeleteRegion(int regionId)
    {
        var regions = await _regionRepo.GetAllAsync();
        var result = "Failed";

        foreach (Region region in regions)
        {
            if (region.Id == regionId)
            {
                await _regionRepo.DeleteAsync(region.Id);
                result = "Deleted Successfully";
            }
        }
        return result;
    }

}