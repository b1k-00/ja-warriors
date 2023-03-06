using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Persistence;
using Domain; 

namespace Application;
public class MeetingApp : IMeetingApp
{
    public IGenericRepository<Meeting> _meetingRepo { get; set; }
    
    public MeetingApp(IGenericRepository<Meeting> meetingRepo)
    {
        _meetingRepo = meetingRepo;
    }

    public async Task<bool> CreateMeeting(Meeting meeting)
    {
        var meetings = await _meetingRepo.GetAllAsync();
        var result = false;

        if (!meetings.Contains(meeting))
        {
            await _meetingRepo.AddAsync(meeting);
            result = true;
        }
        return result;
    }
    //public bool UpdateMeeting()
    //{

    //}
    public async Task<bool> DeleteMeeting(string meetingName)
    {
        var meetings = await _meetingRepo.GetAllAsync();
        var result = false;

        foreach (Meeting meeting in meetings)
        {
            if (meeting.Name == meetingName)
            {
                //await _meetingRepo.DeleteAsync(meeting.Id);
                result = true;
            }
        }
        return result;

    }
    public async Task<List<Meeting>> GetMeetings()
    {
        return (await _meetingRepo.GetAllAsync()).ToList<Meeting>();
    }
}
//talk with Josh or Scott about requirements for these test cases
//cancel button for deleting a meeting? 