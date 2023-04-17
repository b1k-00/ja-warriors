using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence;
public interface IUserAvailabilityApp
{

    Task<List<UserAvailability>> GetAvailabilitybyUser(int userId);

    Task AddUserAvailability(int userId, int availabilityId);

    Task RemoveUserAvailability(int userId, int availabilityId);
}