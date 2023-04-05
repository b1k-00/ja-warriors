using Application;
using Application.Interfaces;
using Application.Persistence;
using Domain;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;

namespace API.Controllers;

public class AvailabilityController : BaseApiAppController<Availability>
{
    IAvailabilityApp _availabilityApp = null;

    IUserAvailabilityApp _userAvailabilityApp = null;

    public AvailabilityController(IAvailabilityApp availabilityApp, IUserAvailabilityApp userAvailabilityApp) : base((IApp<Availability>)availabilityApp)
    {
        _availabilityApp = availabilityApp;

        _userAvailabilityApp = userAvailabilityApp;
    }

    [HttpGet("GetAvailabilityByTime")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Availability>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<Availability>> GetAvailabilitybyTime(DateTime startTime, DateTime endTime)
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

    [HttpGet("AvailabilitySummary")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AvailabilitySummaryDTO>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<AvailabilitySummaryDTO>> GetAvailabilitySummary()
    {
        return await _availabilityApp.GetAvailabilitySummary();
    }

}







