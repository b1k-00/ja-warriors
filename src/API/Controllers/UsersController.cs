using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Application;
using Application.DTOs.DadJoke;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Persistence;
using Persistence.Repositories;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace API.Controllers;
public class UsersController : BaseApiController
{

    IUserApp _userApp = null;

    public UsersController(IUserApp userApp)
    {
        //var test = userApp.GetUsers().Result;
        _userApp = userApp;
    }
    //private static readonly string[] Summaries = new[]
    //    {
    //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //};

    //[HttpGet(Name = "GetUsers")]
    //public IEnumerable<WeatherForecast> Get()
    //{
    //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //    {
    //        Date = DateTime.Now.AddDays(index),
    //        TemperatureC = Random.Shared.Next(-20, 55),
    //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //    })
    //    .ToArray();
    //}

    //[HttpPost("Validate")]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public async Task<bool> ValidateUser(string username, string password)
    //{

    //    return await _userApp.Validate(username, password);
    //}

    [HttpGet("All")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<User>> All()
    {
        //return new List<User>
        //{
        //    new User
        //    {
        //        Id = 1,
        //        FirstName = "hi"
        //    }
        //};
        //var optionsBuilder = new DbContextOptionsBuilder<JuniorAssociateDbContext>();
        //optionsBuilder.UseSqlServer("Server=japrogram-dotnet-spring23.cwwfdfofewj7.us-east-1.rds.amazonaws.com; User Id=jadbadmin; Password=0s3EIeRwmryBrFsKT8dD; Initial Catalog=JAScheduler_DEV; MultipleActiveResultSets=True; Connection Timeout=30;");
        //JuniorAssociateDbContext dbContext = new JuniorAssociateDbContext(optionsBuilder.Options);
        //UserRepository userRepo = new UserRepository(dbContext);
        //UserApp userApp = new UserApp(userRepo);
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
