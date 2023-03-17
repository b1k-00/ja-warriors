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
        _userApp = userApp;
    }


    [HttpPost("CreateUser")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<bool> CreateUser(User user)
    {

        return await _userApp.CreateUser(user);
    }

    [HttpPost("UpdateUser")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<string> UpdateUser(User user)
    {
        return await _userApp.UpdateUser(user);
    }

    [HttpPost("Validate")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<bool> ValidateUser(string username, string password)
    {

        return await _userApp.Validate(username, password);
    }

    [HttpPost("Delete")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<bool> DeleteUser(string username)
    {
        return await _userApp.DeleteUser(username);

    }

    [HttpGet("AllUsers")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<User>> AllUsers()
    {
        var just = await _userApp.GetUsers();
        return await _userApp.GetUsers();
    }

    [HttpGet("AllUsersByDesignStudio")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<User>> GetUserByDesignStudio(int designStudioId)
    {
        return await _userApp.GetUserByDesignStudio(designStudioId);
    }


}
