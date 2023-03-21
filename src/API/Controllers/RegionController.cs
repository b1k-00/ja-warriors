using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class RegionController : BaseApiAppController<Region>
{
    public IRegionApp _regionApp = null;

    public RegionController(IRegionApp regionApp) : base((IApp<Region>)regionApp)
    {
        _regionApp = regionApp;
    }
}
