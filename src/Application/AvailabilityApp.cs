using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Persistence;
using Domain;

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

}
