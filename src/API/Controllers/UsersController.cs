using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Application;
using Application.DTOs.DadJoke;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace API.Controllers;
public class UsersController : BaseApiController
{

    IUserApp _userApp = null;

    public UsersController(IUserApp userApp)
    {
        var test = userApp.GetUsers().Result;
        _userApp = userApp;
    }

    [HttpPost("Validate")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<bool> ValidateUser(string username, string password)
    {

        return await _userApp.Validate(username, password);
    }

    [HttpGet("AllUsers")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<User>> AllUsers()
    {
        return await _userApp.GetUsers();
    }

    [HttpPost("CreateUser")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<bool> CreateUser(User user)
    {

        return await _userApp.CreateUser(user);
    }

    [HttpPost("Delete")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<bool> DeleteUser(string username)
    {
        return await _userApp.DeleteUser(username);

    }
}
