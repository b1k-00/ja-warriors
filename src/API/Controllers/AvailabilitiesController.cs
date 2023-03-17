using Application;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AvailabilityController : BaseApiController
{
    IAvailabilityApp _availabilityApp = null;

    IAvailabilityApp _userAvailabilityApp = null;

    public AvailabilityController(IAvailabilityApp availabilityApp)
    {
        _availabilityApp = availabilityApp;
    }

    [HttpPost("CreateAvailability")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<string> CreateAvailability(Availability availability)
    {

        return await _availabilityApp.CreateAvailability(availability);
    }

    [HttpPost("UpdateAvailability")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<string> UpdateAvailability(Availability availability)
    {
        return await _availabilityApp.UpdateAvailability(availability);
    }

    [HttpPost("DeleteAvailability")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<string> DeleteAvailability(int availabilityId)
    {
        return await _availabilityApp.DeleteAvailability(availabilityId);

    }

    [HttpGet("AllAvailabilities")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Availability>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<Availability>> AllAvailabilities()
    {
        return await _availabilityApp.GetAvailabilities();
    }

    [HttpGet("GetAvailabilityByTime")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Availability>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<Availability>> GetAvailabilitybyTime(string StartTime, string EndTime) //TODO
    {
        return await _availabilityApp.GetAvailabilitybyTime(StartTime, EndTime);
    }


    [HttpGet("GetAvailabilitiesByAvailabilityId")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Availability))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<Availability> GetAvailabilityId(int id)
    {
        return await _availabilityApp.GetAvailabilityId(id);
    }

    [HttpGet("AvailabilitybyUserId")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserAvailability>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<UserAvailability>> GetAvailabilitybyUser(int UserId)
    {
        return await _userAvailabilityApp.GetAvailabilitybyUser(UserId);
    }

}





