using Application;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace API.Controllers;

public class LocationController : BaseApiController
{
    IDesignStudioApp _designStudioApp = null;

    IRegionApp _regionApp = null;

    public LocationController(IDesignStudioApp designStudioApp, IRegionApp regionApp)
    {
        _designStudioApp = designStudioApp;

        _regionApp = regionApp;
    }

    [HttpPost("CreateRegion")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<string> CreateRegion(Region region)
    {
        return await _regionApp.CreateRegion(region);
    }

    [HttpPost("CreateDesignStudio")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<string> CreateDesignStudio(DesignStudio designStudio)
    {
        return await _designStudioApp.CreateDesignStudio(designStudio);
    }

    [HttpPost("UpdateRegion")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<string> UpdateRegion(Region region)
    {
        return await _regionApp.UpdateRegion(region);
    }

    [HttpPost("UpdateDesignStudio")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<string> UpdateDesignStudio(DesignStudio designStudio)
    {
        return await _designStudioApp.UpdateDesignStudio(designStudio);
    }

    [HttpPost("DeleteRegion")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<string> DeleteRegion(int regionId)
    {
        return await _regionApp.DeleteRegion(regionId);

    }

    [HttpPost("DeleteDesignStudio")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<string> DeleteDesignStudio(int designStudioId)
    {
        return await _designStudioApp.DeleteDesignStudio(designStudioId);

    }

    [HttpGet("GetARegion")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Region))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<Region> GetRegion(int id)
    {
        return await _regionApp.GetRegion(id);
    }

    [HttpGet("GetADesignStudio")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DesignStudio))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<DesignStudio> GetDesignStudio(int id)
    {
        return await _designStudioApp.GetDesignStudio(id);
    }

    [HttpGet("AllRegions")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Region>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<Region>> AllRegions()
    {
        return await _regionApp.GetAllRegions();
    }

    [HttpGet("AllDesignStudiosByRegion")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DesignStudio>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<DesignStudio>> GetDesignStudiosByRegion(int regionId)
    {
        return await _designStudioApp.GetDesignStudiosByRegion(regionId);
    }

    [HttpGet("AllDesignStudios")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DesignStudio>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<DesignStudio>> GetDesignStudios()
    {
        return await _designStudioApp.GetDesignStudios();
    }
}
