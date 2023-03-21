using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Persistence;
using Domain;

namespace Application;
public class UserApp : AppBase<User>, IUserApp, IApp<User>
{
    public IGenericRepository<User> _userRepo { get; set; }
    public UserApp(IGenericRepository<User> userRepo) : base(userRepo)
    {
        _userRepo = userRepo;

    }

    public async Task<bool> Validate(string username, string password)
    {

        var result = false;
        var users = await _userRepo.GetAllAsync();

        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
            foreach (User user in users)
            {

                if (user.Email == username && user.Password == password)
                {
                    result = true;
                }
            }
        }

        return result;

    }


    public async Task<List<User>> GetUserByDesignStudio(int designStudioId)
    {
        try
        {
            var test0 = _userRepo.GetAllAsync().Result;
            var test1 = (await _userRepo.GetAllAsync()).Where(x => x.DesignStudiosId == designStudioId).ToList<User>();
            var test3 = (await _userRepo.GetAllAsync()).ToList<User>();
        }
        catch (Exception ex)
        {
            var stop = 1;
        }

        return (await _userRepo.GetAllAsync()).Where(x => x.DesignStudiosId == designStudioId).ToList<User>();
    }

}
