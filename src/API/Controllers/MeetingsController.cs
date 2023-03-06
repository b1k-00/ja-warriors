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
        var result = new List<Meeting>();
        try
        {
            result = await _meetingApp.GetMeetings();
        }
        catch(Exception ex)
        {
            var stop = 1; 
        }

        return result;
    }

    //[HttpGet("All")]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Meeting>))]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public async Task<List<Meeting>> All()
    //{
    //    //return new List<User>
    //    //{
    //    //    new User
    //    //    {
    //    //        Id = 1,
    //    //        FirstName = "hi"
    //    //    }
    //    //};
    //    //var optionsBuilder = new DbContextOptionsBuilder<JuniorAssociateDbContext>();
    //    //optionsBuilder.UseSqlServer("Server=japrogram-dotnet-spring23.cwwfdfofewj7.us-east-1.rds.amazonaws.com; User Id=jadbadmin; Password=0s3EIeRwmryBrFsKT8dD; Initial Catalog=JAScheduler_DEV; MultipleActiveResultSets=True; Connection Timeout=30;");
    //    //JuniorAssociateDbContext dbContext = new JuniorAssociateDbContext(optionsBuilder.Options);
    //    //UserRepository userRepo = new UserRepository(dbContext);
    //    //UserApp userApp = new UserApp(userRepo);
    //    return await _meetingApp.GetMeetings();
    //}

    //[HttpPost("CreateMeeting")]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public async Task<bool> CreateMeeting(Meeting meeting)
    //{

    //    return await _meetingApp.CreateMeeting(meeting);
    //}

    //[HttpPost("DeleteMeeting")]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public async Task<bool> DeleteMeeting(string meetingName)
    //{
    //    return await _meetingApp.DeleteMeeting(meetingName);

    //}
}
