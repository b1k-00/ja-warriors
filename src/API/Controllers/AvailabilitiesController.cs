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
        
        Random rnd = new Random();

        List<AvailabilitySummaryDTO> result = new List<AvailabilitySummaryDTO>();

        DateTime startTime = new DateTime(2000, 01, 01, 06, 00, 00, DateTimeKind.Utc);

        DateTime endTime = new DateTime(2000, 01, 01, 18, 00, 00, DateTimeKind.Utc);

        List<AvailabilitySummaryValueDTO> userCounts = new List<AvailabilitySummaryValueDTO>();

        int dayOfWeek = 1;

        for (; dayOfWeek <= 5; dayOfWeek++)
        {
            AvailabilitySummaryDTO availabilitySummaryDTO = new AvailabilitySummaryDTO();

            availabilitySummaryDTO.DayOfWeek = dayOfWeek;

            startTime = new DateTime(2000, 01, 01, 06, 00, 00, DateTimeKind.Utc);

            while (startTime < endTime)
            {
                AvailabilitySummaryValueDTO availabilitySummary = new AvailabilitySummaryValueDTO()
                {

                    StartTime = startTime,
                    UserCount = rnd.Next(1, 5),

                };
                availabilitySummaryDTO.UserCounts.Add(availabilitySummary);

                startTime = startTime.AddMinutes(30);

            }

            result.Add(availabilitySummaryDTO);

        }

        return result;
    }
    
}







