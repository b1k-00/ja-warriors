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

    List<User> users = new List<User>();



    public UserApp()
    {


    }
    public bool CreateUser(User user)
    {
        if (users.Contains(user))
        {
            var result = false;
            return result;
        }

        else
        {
            users.Add(user);
            var result = true;
            return result;
        }
    }

    public bool DeleteUser(string username)
    {

        var result = false;

        foreach (User user in users)
        {
            if (user.Email == username)
            {
                users.Remove(user);
                result = true;
                return result;
            }
        }
        return result;

    }

    public List<User> GetUsers()
    {
        return users;
    }

    public bool Validate(string username, string password)
    {

        var result = false;

        if (!string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
        {
            return result;
        }

        foreach (User user in users)
        {

            if (user.Email == username && user.Password == password)
            {
                result = true;
                return result;
            }
        }

        return result;

    }

}
