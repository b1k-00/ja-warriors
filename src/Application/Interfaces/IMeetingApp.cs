using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;
public interface IMeetingApp
{
    Task<bool> CreateMeeting(Meeting meeting);

    Task<bool> DeleteMeeting(string meetingName);

    Task<List<Meeting>> GetMeetings();
}
