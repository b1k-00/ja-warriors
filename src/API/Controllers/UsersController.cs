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

    UserApp userApp = new UserApp();

    public UsersController()
    {
    }

    [HttpPost("Validate")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public bool ValidateUser(string username, string password)
    {

        return userApp.Validate(username, password);
    }

    [HttpGet("AllUsers")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public List<User> AllUsers()
    {
        return userApp.GetUsers();
    }

    [HttpPost("CreateUser")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public bool CreateUser(User user)
    {

        return userApp.CreateUser(user);
    }

    [HttpPost("Delete")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public bool DeleteUser(string username)
    {
        return userApp.DeleteUser(username);

    }
}
