using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Application;
using Application.DTOs.DadJoke;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace API.Controllers;
public class UsersController : BaseApiController        
{
    public UsersController()
    {
    }
    
    [HttpPost("Validate")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public bool ValidateUser(string username, string password)
    {
        var result = false;

        var users = UserApp.GetUsers();

        var foundUser = users.Find(y => y.Email == username);

        result = foundUser != null && foundUser.Password == password;

        return result;
    }
    
    [HttpGet("AllUsers")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public List<User> AllUsers()
    {
        return UserApp.GetUsers();
    }

    [HttpPost("CreateUser")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public bool CreateUser(User user)
    {
        var result = false;

        var users = UserApp.GetUsers();


        if (user == null)
        {
            result = false;
        }
        else
        {
            users.Add(user);

            result = true;
        }
        return result;
    }

    [HttpPost("Delete")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public bool DeleteUser(string username) 
    {
        var result = false;

        var users = UserApp.GetUsers();

        var delUser = users.Find(y => y.Email == username);

        if (delUser == null)
        {
            result = false;
        }
        else
        {
            users.Remove(delUser);
            result = true;
        }
        return result; 

    }
}
