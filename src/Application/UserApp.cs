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
    public IGenericRepository<User> _userRepo { get; set; }
    public UserApp(IGenericRepository<User> userRepo)
    {
        _userRepo = userRepo;

    }
    public async Task<bool> CreateUser(User user)
    {
        var users = await _userRepo.GetAllAsync();
        var result = true;

        if (!users.Select(x => x.Email).Contains(user.Email))
        {
            await _userRepo.AddAsync(user);
            result = false;
        }
        return result;

    }

    public async Task<string> UpdateUser(User user)
    {
        var result = "Updated Successfully";
        try
        {

            await _userRepo.UpdateAsync(user);
        }

        catch (Exception ex)
        {
            result = "Update Failed";
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
                await _userRepo.DeleteAsync(user.Id);
                result = true;
            }
        }
        return result;
    }

    public async Task<List<User>> GetUsers()
    {
        try
        {
            var test0 = _userRepo.GetAllAsync().Result;
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

    public async Task<User> GetUser(int id)
    {
        var user = await _userRepo.GetAsync(id);
        return user;
    }

}
