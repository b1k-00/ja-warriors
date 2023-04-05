using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Persistence;
using Domain;
using Domain.DTO;

namespace Application;
public class AvailabilityApp : AppBase<Availability>, IAvailabilityApp, IApp<Availability>
{
    public IGenericRepository<Availability> _availabilityRepo { get; set; }

    public IGenericRepository<UserAvailability> _userAvailabilityRepo { get; set; }

    public IGenericRepository<User> _userRepo { get; set; }


    // Put in Order
    public AvailabilityApp(IGenericRepository<Availability> availabilityRepo, IGenericRepository<User> userRepo,
        IGenericRepository<UserAvailability> userAvailabilityRepo) : base(availabilityRepo)
    {
        _availabilityRepo = availabilityRepo;

        _userAvailabilityRepo = userAvailabilityRepo;

        _userRepo = userRepo;


    }




    public async Task<bool> ScheduleAvailability(UserAvailability userAvailability)
    {
        var availabilities = await _userAvailabilityRepo.GetAllAsync(); 
        var result = false;

        if (!availabilities.Contains(userAvailability))
        {
            await _userAvailabilityRepo.AddAsync(userAvailability);
            result = true;
        }
        return result;
    }

    public async Task<List<UserAvailability>> GetUserAvailabilities()
    {
        List<UserAvailability> result = new List<UserAvailability>();
        try
        {
            result = (await _userAvailabilityRepo.GetAllAsync()).ToList<UserAvailability>();
        }
        catch (Exception ex)
        {
            result = new List<UserAvailability> { };
        }
        return result;
    }

    public async Task<List<Availability>> GetAvailabilitybyTime(DateTime startTime, DateTime endTime)
    {
        List<Availability> result = new List<Availability>();
        try
        {
            result = (await _availabilityRepo.GetAllAsync()).Where(x => x.startTime == startTime).ToList<Availability>();
        }
        catch (Exception ex)
        {
            result = new List<Availability> { };
        }

        return result;
    }
    public async Task<List<AvailabilitySummaryDTO>> GetAvailabilitySummary()
    {
        List<AvailabilitySummaryDTO> result = new List<AvailabilitySummaryDTO>();

        DateTime startTime = new DateTime(2000, 01, 01, 06, 00, 00, DateTimeKind.Utc);

        DateTime endTime = new DateTime(2000, 01, 01, 18, 00, 00, DateTimeKind.Utc);

        List<UserAvailability> userAvailabilities = (await _userAvailabilityRepo.GetAllAsync()).ToList();

        List<Availability> availabilities = (await _availabilityRepo.GetAllAsync()).ToList();


        int dayOfWeek = 1;

        for (; dayOfWeek <= 5; dayOfWeek++)
        {
            startTime = new DateTime(2000, 01, 01, 06, 00, 00, DateTimeKind.Utc);

            AvailabilitySummaryDTO availabilitySummaryDTO = new AvailabilitySummaryDTO();

            availabilitySummaryDTO.DayOfWeek = dayOfWeek;

            while (startTime < endTime)
            {
                var count = 0;

                var currentAvailability = availabilities.Where(x => startTime.ToString("HHmmss") == x.startTime.ToString("HHmmss") 
                && (dayOfWeek == x.DayOfTheWeek)).ToList().FirstOrDefault();

                    count = 0;

                    var summaryValue = new AvailabilitySummaryValueDTO();

                    summaryValue.StartTime = startTime.ToString("HH:mm");
                   
                    if (summaryValue != null && currentAvailability != null)
                    {
                        var availabilityId = currentAvailability.Id;                       

                        userAvailabilities.ForEach(userAvailability =>
                        {
                            if (userAvailability.AvailabilityId == currentAvailability.Id)
                            {
                                count++;
                            }
                        });                      
                    }
                summaryValue.UserCount = count;

                availabilitySummaryDTO.Summaries.Add(summaryValue);
               
                startTime = startTime.AddMinutes(30);              
            }
            result.Add(availabilitySummaryDTO);
        }
        return result;
    }
   
}
