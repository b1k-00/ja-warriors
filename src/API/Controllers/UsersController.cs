using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Application;
using Application.DTOs.DadJoke;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using Application.Interfaces;

namespace API.Controllers;
public class UsersController : BaseApiAppController<User>
{
    IHttpContextAccessor _contextAccessor = null;
    IUserApp _userApp = null;

    public UsersController(IUserApp userApp, IHttpContextAccessor contextAccessor) : base((IApp<User>)userApp)
    {
        _contextAccessor = contextAccessor;
        //var stop = GetUserNameFromJwt();
        var stop3 = 1;
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

    [HttpGet("JWT")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<string> GetUserNameFromJwt()
    {
        string result = "";

        try
        {
            StringValues authorizationToken = "";

            var headers = _contextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out authorizationToken);
            var jwtString = authorizationToken.ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtString);
            var tokenS = jsonToken as JwtSecurityToken;
            result = tokenS.Claims.First(claim => claim.Type == "username").Value;
        }
        catch(Exception ex)
        {
            var stop = 1;
        }
        
        return result;
    }
}
