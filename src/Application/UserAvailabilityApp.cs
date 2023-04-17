using Application.Interfaces;
using Application.Persistence;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application;
public class UserAvailabilityApp : IUserAvailabilityApp
{
    public IGenericRepository<UserAvailability> _userAvailabilityRepo { get; set; }


    public UserAvailabilityApp(IGenericRepository<UserAvailability> userAvailabilityRepo)
    {
        _userAvailabilityRepo = userAvailabilityRepo;
    }

    public async Task<List<UserAvailability>> GetAvailabilitybyUser(int userId)
    {
        List<UserAvailability> result = new List<UserAvailability>();
        try
        {
            result = (await _userAvailabilityRepo.GetAllAsync()).Where(x => x.UserId == userId).ToList<UserAvailability>();
        }
        catch (Exception ex)
        {
            result = new List<UserAvailability> { };
        }

        return result;

    }

    public async Task AddUserAvailability(int userId, int availabilityId)
    {
        UserAvailability userAvailability = new UserAvailability()
        {
            UserId = userId,
            AvailabilityId = availabilityId,

        };


        await _userAvailabilityRepo.AddAsync(userAvailability);
    }

    public async Task RemoveUserAvailability(int userId, int availabilityId)
    {
        var userAvailabilities = await _userAvailabilityRepo.GetAllAsync();

        UserAvailability userAvailabilityRemove = null;

        foreach (UserAvailability userAvailability in userAvailabilities)
        {
            if (userId == userAvailability.UserId && availabilityId == userAvailability.AvailabilityId)
            {
                userAvailabilityRemove = userAvailability;

                break;


            }

        }
        if (userAvailabilityRemove != null)
        {
            await _userAvailabilityRepo.DeleteAsync(userAvailabilityRemove.Id);
        }



    }
}
