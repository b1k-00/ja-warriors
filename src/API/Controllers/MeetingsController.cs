using Application;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MeetingsController : BaseApiController
{
    IMeetingApp _meetingApp = null;

    public MeetingsController(IMeetingApp meetingApp)
    {
        _meetingApp = meetingApp;
    }

    [HttpGet("AllMeetings")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Meeting>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<Meeting>> AllMeetings()
    {
        return await _meetingApp.GetMeetings();
    }

    [HttpPost("CreateMeeting")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<bool> CreateMeeting(Meeting meeting)
    {

        return await _meetingApp.CreateMeeting(meeting);
    }

    //[HttpPost("DeleteMeeting")]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public async Task<bool> DeleteMeeting(string meetingName)
    //{
    //    return await _meetingApp.DeleteMeeting(meetingName);

    //}
}
