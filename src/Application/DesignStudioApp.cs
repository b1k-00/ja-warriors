using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Persistence;
using Domain;

namespace Application;
public class DesignStudioApp : IDesignStudioApp
{
    public IGenericRepository<DesignStudio> _designStudioRepo { get; set; }

    public DesignStudioApp(IGenericRepository<DesignStudio> designStudioRepo)
    {
        _designStudioRepo = designStudioRepo;
    }

    public async Task<List<DesignStudio>> GetDesignStudios()
    {
        List<DesignStudio> result = new List<DesignStudio>();
        try
        {  
            result = (await _designStudioRepo.GetAllAsync()).ToList<DesignStudio>();
        }
        catch (Exception ex)
        {
            result = new List<DesignStudio>();
        }

        return result;
    }

    public async Task<DesignStudio> GetDesignStudio(int id)
    {
        var designStudio = await _designStudioRepo.GetAsync(id);
   
        return designStudio;
    }

    public async Task<List<DesignStudio>> GetDesignStudiosByRegion(int regionId)
    {
        List<DesignStudio> result = new List<DesignStudio>();
        try
        {
            result = (await _designStudioRepo.GetAllAsync()).Where(x => x.RegionId == regionId).ToList<DesignStudio>();
        }
        catch (Exception ex)
        {
            result = new List<DesignStudio>();
        }

        return result;

    }

    public async Task<string> CreateDesignStudio(DesignStudio designStudio)
    {
        var newCenter = await _designStudioRepo.GetAllAsync();
        var result = "Unable to add!";

        if (!newCenter.Select(x => x.Name).Contains(designStudio.Name))
        {
            await _designStudioRepo.AddAsync(designStudio);
            result = "Successfully Added!";
        }
        return result;

    }

    public async Task<string> UpdateDesignStudio(DesignStudio designStudio)
    {
        var test = _designStudioRepo.UpdateAsync(designStudio);

        return "Updated Successfully";

    }

    public async Task<string> DeleteDesignStudio(int designStudioId)
    {
        var designStudios = await _designStudioRepo.GetAllAsync();
        var result = "Failed";

        foreach (DesignStudio designStudio in designStudios)
        {
            if (designStudio.Id == designStudioId)
            {
                await _designStudioRepo.DeleteAsync(designStudio.Id);
                result = "Deleted Successfully";
            }
        }
        return result;
    }
}