using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Persistence;
using Domain;

namespace Application;

public class DesignStudioApp : AppBase<DesignStudio>, IDesignStudioApp, IApp<DesignStudio>
{
    public IGenericRepository<DesignStudio> _designStudioRepo { get; set; }

    public DesignStudioApp(IGenericRepository<DesignStudio> designStudioRepo) : base(designStudioRepo)
    {
        _designStudioRepo = designStudioRepo;
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

}