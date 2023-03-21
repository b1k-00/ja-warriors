using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class DesignStudioController : BaseApiAppController<DesignStudio>
{
    public IDesignStudioApp _designStudioApp = null;

    public DesignStudioController(IDesignStudioApp designStudioApp) : base((IApp<DesignStudio>)designStudioApp)
    {
        _designStudioApp = designStudioApp;
    }

    [HttpGet("AllDesignStudiosByRegion")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DesignStudio>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<DesignStudio>> GetDesignStudiosByRegion(int regionId)
    {
        return await _designStudioApp.GetDesignStudiosByRegion(regionId);
    }
}
