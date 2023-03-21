using Application;
using Application.Interfaces;
using Application.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AvailabilityController : BaseApiAppController<Availability>
{
    IAvailabilityApp _availabilityApp = null;

    IUserAvailabilityApp _userAvailabilityApp = null;

    public AvailabilityController(IAvailabilityApp availabilityApp, IUserAvailabilityApp userAvailabilityApp) : base((IApp<Availability>) availabilityApp)
    {
        _availabilityApp = availabilityApp;

        _userAvailabilityApp = userAvailabilityApp;
    }


    [HttpGet("GetAvailabilityByTime")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Availability>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<Availability>> GetAvailabilitybyTime(string startTime, string endTime) //TODO
    {
        return await _availabilityApp.GetAvailabilitybyTime(startTime, endTime);
    }


    [HttpGet("AvailabilitybyUserId")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserAvailability>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<UserAvailability>> GetAvailabilitybyUser(int userId)
    {
        return await _userAvailabilityApp.GetAvailabilitybyUser(userId);
    }

}





