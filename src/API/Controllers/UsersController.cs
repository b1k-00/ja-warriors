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
        var stop3 = 1;
        _userApp = userApp;
    }

    [HttpPost("Add")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public override async Task<User> Create(User entity)
    {
        var aws = await GetJwt();
        if (!string.IsNullOrWhiteSpace(aws))
        {
            entity.AwsId = new Guid(aws);
        }
        return await ((IApp<User>)_userApp).Create(entity);
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
        return await GetJwt();
    }

    private async Task<string> GetJwt()
    {
        string result = "";

        try
        {
            StringValues authorizationToken = "";

           
            var headers = _contextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out authorizationToken);
            if (!string.IsNullOrWhiteSpace(authorizationToken))
            {
                var jwtString = authorizationToken.ToString().Replace("Bearer ", "");
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(jwtString);
                var tokenS = jsonToken as JwtSecurityToken;
                result = tokenS.Claims.First(claim => claim.Type == "username").Value;
            }
        }
        catch (Exception ex)
        {
            var stop = 1;
        }

        return result;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public override async Task<List<User>> All()
    {
        List<User> result = new List<User>();

        var users = await ((IApp<User>)_userApp).GetAll();
        foreach (var user in users)
        {
            user.IsManager = user.RoleId == 2;
        }
        return users;
    }
}
