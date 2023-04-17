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

    [HttpPost("AddUserAvailability")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AvailabilitySummaryDTO>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task AddUserAvailability(int userId, int availabilityId)
    {
        await _userAvailabilityApp.AddUserAvailability(userId, availabilityId);
    }


    [HttpPost("AddUserAvailabilityByTime")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AvailabilitySummaryDTO>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task AddUserAvailabilityByTime(int userId, string startTime, int dayOfWeek)
    {
       var availability = await GetAvailabilityByTime(startTime, dayOfWeek);

        if (availability != null)
        {

            await _userAvailabilityApp.AddUserAvailability(userId, availability.Id);
        }

    }

    [HttpPost("RemoveUserAvailabilityByTime")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AvailabilitySummaryDTO>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task RemoveUserAvailabilityByTime(int userId, string startTime, int dayOfWeek)
    {
        var availability = await GetAvailabilityByTime(startTime, dayOfWeek);

        if (availability != null)
        {

            await _userAvailabilityApp.RemoveUserAvailability(userId, availability.Id);
        }

    }



    private async Task<Availability> GetAvailabilityByTime(string startTime, int dayOfWeek)
    {
        Availability result = null;

        List<Availability> allAvailabilities = await ((IApp<Availability>)_availabilityApp).GetAll();

        DateTime dateTime = DateTime.Now;

        startTime = "1900/01/01 " + startTime;

        DateTime.TryParse(startTime, out dateTime);

        foreach (var availability in allAvailabilities)
        {
            if (availability.startTime == dateTime && availability.DayOfTheWeek == dayOfWeek)
            {
                result = availability;

                break;

            }


        }

        return result;
    }

}







