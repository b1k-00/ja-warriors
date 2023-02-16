using Amazon.CognitoIdentityProvider;
using API.Controllers;
using Application;
using Application.DTOs.DadJoke;
using Application.Requests.DadJoke.Queries;
using Domain;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ApiUnitTests;

public class UserAppTests
{

    [Fact]
    public void CreateUser_Fail_DuplicateEntry()
    {
        UserApp app = new UserApp();

        User user1 = new User();

        //give new user an email
        user1.Email = "brennen.collins@ruralsourcing.com";

        //added user to my local DB list
        app.CreateUser(user1);

        //added the same user
        app.CreateUser(user1);

        //count how many users I should have
        var initialCount = app.GetUsers().Count;

        //how many users should actually be here
        Assert.Equal(initialCount, 1);

    }

    [Fact]
    public void Validate_Success()
    {
        UserApp app = new UserApp();

        User user = new User();

        user.Email = "brennen.collins@ruralsourcing.com";
        user.Password = "Kob324";

        //added new user to the list w/ CU method
        var add = app.CreateUser(user);

        //validate the values passed
        var result = app.Validate(user.Email, user.Password);

        Assert.Equal(result, true);
    }

    [Fact]
    public void Validate_Failure()
    {
        UserApp app = new UserApp();

        User user = new User();

        user.Email = "Test";
        user.Password = "gg";

        User user1 = new User();
        user1.Email = "Bless";
        user1.Password = "yes";

        var add = app.CreateUser(user);

        var result = app.Validate(user1.Email, user1.Password);

        Assert.Equal(result, false);


    }

    [Fact]

    public void RemoveUser_Success()
    {
        UserApp app = new UserApp();

        User user = new User();

        var add = app.CreateUser(user);

        var initialCount = app.GetUsers().Count;

        var del = app.DeleteUser(user.Email);

        var finalCount = app.GetUsers().Count;

        Assert.Equal(initialCount, 1);

        Assert.Equal(finalCount, 0);

        Assert.Equal(del, true);


    }

    [Fact]
    public void RemoveUser_Failure()
    {//failed xUnit
        UserApp app = new UserApp();

        User user = new User();
        user.Email = "test";
        user.Password = "hh";

        var add = app.CreateUser(user);

        var initialCount = app.GetUsers().Count;

        var del = app.DeleteUser("oo");

        var finalCount = app.GetUsers().Count;

        Assert.Equal(del, false);

        Assert.Equal(initialCount, finalCount);
    }

    [Fact]

    public void CreateUser_Success()
    {
        UserApp app = new UserApp();

        User user = new User();

        user.Email = "Test";
        user.Password = "jj";

        var add = app.CreateUser(user);

        Assert.Equal(add, true);


    }

    [Fact]

    public void CreateUser_Failure()
    {
        UserApp app = new UserApp();

        User user = new User();
        user.Email = "Test";
        user.Password = "gg";

        var add = app.CreateUser(user);

        var initialCount = app.GetUsers().Count;

        var duplicate = app.CreateUser(user);

        var finalCount = app.GetUsers().Count;

        Assert.Equal(duplicate, false);

        Assert.Equal(finalCount, initialCount);
    }

    [Fact]

    public void GetUser_Success()
    {
        UserApp app = new UserApp();

        var initialCount = app.GetUsers().Count;

        var finalCount = app.GetUsers().Count;

        Assert.Equal(initialCount, finalCount);
    }
}
