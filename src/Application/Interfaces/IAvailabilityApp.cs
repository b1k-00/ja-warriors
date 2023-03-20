using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;
public interface IAvailabilityApp
{
    Task<string> CreateAvailability(Availability availability);

    Task<bool> ScheduleAvailability(UserAvailability useravailability);

    Task<List<Availability>> GetAvailabilities();

    Task<List<UserAvailability>> GetUserAvailabilities();

    Task<List<Availability>> GetAvailabilitybyTime(string StartTime, string EndTime);


    Task<string> DeleteAvailability(int availabilityId);


    Task<string> UpdateAvailability(Availability availability);

    Task<Availability> GetAvailabilityId(int id);


}
