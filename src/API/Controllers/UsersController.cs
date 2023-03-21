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
public class UsersController : BaseApiAppController<User>
{

    IUserApp _userApp = null;

    public UsersController(IUserApp userApp) : base((IApp<User>) userApp)
    {
        _userApp = userApp;
    }

    [HttpPost("Validate")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<bool> ValidateUser(string username, string password)
    {

        return await _userApp.Validate(username, password);
    }


    [HttpGet("AllUsersByDesignStudio")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<User>> GetUserByDesignStudio(int designStudioId)
    {
        return await _userApp.GetUserByDesignStudio(designStudioId);
    }


}
