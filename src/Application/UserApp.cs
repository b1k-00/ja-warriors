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
public class UserApp : IUserApp
{

    //List<User> users = new List<User>();
    public IGenericRepository<User> _userRepo { get; set; }




    public UserApp(IGenericRepository<User> userRepo)
    {
        _userRepo= userRepo;

    }
    public async Task<bool> CreateUser(User user)
    {
        var users = await _userRepo.GetAllAsync();
        var result = false;

        if (!users.Contains(user))
        { 
            await _userRepo.AddAsync(user);
            result = true;
        }
        return result;

    }

    public async Task<bool> DeleteUser(string username)
    {
        var users = await _userRepo.GetAllAsync();
        var result = false;

        foreach (User user in users)
        {
            if (user.Email == username)
            {
                //await _userRepo.DeleteAsync(user.Id);
                result = true;
            }
        }
        return result;

    }

    public async Task<List<User>> GetUsers()
    {
        try
        {
            var test0 =  _userRepo.GetAllAsync().Result;
            var test1 = (await _userRepo.GetAllAsync());
            var test = (await _userRepo.GetAllAsync()).ToList<User>();

        }
        catch (Exception ex)
        {
            var stop = 1;
        }
        
        return (await _userRepo.GetAllAsync()).ToList<User>();
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

}
