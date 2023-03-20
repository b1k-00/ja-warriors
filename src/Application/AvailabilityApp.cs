using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Persistence;
using Domain;

namespace Application;
public class AvailabilityApp : IAvailabilityApp
{
    public IGenericRepository<Availability> _availabilityRepo { get; set; }

    public IGenericRepository<UserAvailability> _userAvailabilityRepo { get; set; }

    public IGenericRepository<User> _userRepo { get; set; }


    // Put in Order
    public AvailabilityApp(IGenericRepository<Availability> availabilityRepo, IGenericRepository<User> userRepo,
        IGenericRepository<UserAvailability> userAvailabilityRepo)
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

    public async Task<List<Availability>> GetAvailabilitybyTime(string startTime, string endTime)
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

    public async Task<string> CreateAvailability(Availability availability)
    {
        var availabilities = await _availabilityRepo.GetAllAsync();
        var result = "Failed";

        if (!availabilities.Contains(availability))
        {
            await _availabilityRepo.AddAsync(availability);
            result = "Created Successfully";
        }
        return result;
    }

    public async Task<string> UpdateAvailability(Availability availability)
    {
        var result = "Updated Successfully";

        try
        {
            await _availabilityRepo.UpdateAsync(availability);
        }
        catch (Exception ex)
        {
            result = "Updated failed";
        }

        return result;
    }

    public async Task<string> DeleteAvailability(int availabilityId)
    {
        var availabilities = await _availabilityRepo.GetAllAsync();
        var result = "Failed";

        foreach (Availability availability in availabilities)
        {
            if (availability.Id == availabilityId)
            {
                await _availabilityRepo.DeleteAsync(availability.Id);
                result = "Deleted Successfully";
            }
        }
        return result;
    }

    public async Task<List<Availability>> GetAvailabilities() //TODO EXAMPLE
    {
        List<Availability> result = new List<Availability>();
        try
        {
            result = (await _availabilityRepo.GetAllAsync()).ToList<Availability>();

        }
        catch (Exception ex)
        {
            result = new List<Availability> { };
        }

        return result;
    }

    public async Task<Availability> GetAvailabilityId(int id)
    {
        var availability = await _availabilityRepo.GetAsync(id);
        return availability;
    }
}
