using Application;
using Application.Interfaces;
using Application.Persistence;
using Domain;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ApiUnitTests;

public class UserAppTests
{
    IUserApp _app = null;

    IDesignStudioApp _designStudioApp = null;

    List<User> _users = new List<User>()
    {
        new User
        {
            Id = 1,
            Email = "brennen.collins@teamsparq.com",
            FirstName= "Brennen",
            LastName= "Collins",
            Graduated= true,
            GraduatedDate = DateTime.Now,
            MiddleName= "Heath",
            Password= "Le6ron1",
            PhoneNumber= "555-645-6932",
            RoleId = 1
        },
          new User
        {
            Id = 2,
            Email = "libby.blair@teamsparq.com",
            FirstName= "Libby",
            LastName= "Blair",
            Graduated= true,
            GraduatedDate = DateTime.Now,
            MiddleName= "Elizabeth",
            Password= "Bl@ir1",
            PhoneNumber= "555-888-5124",
            RoleId = 2
        },
    };


    User user = new User()
    {
        Id = 3,
        Email = "andrew.ringle@teamsparq.com",
        FirstName = "Andrew",
        LastName = "Ringle",
        Graduated = true,
        GraduatedDate = DateTime.Now,
        MiddleName = "Anthony",
        Password = "Kobe@234",
        PhoneNumber = "555-555-5555",
        RoleId = 2

    };

    List<DesignStudio> _designStudios = new List<DesignStudio>()
    {
        new DesignStudio
        {
            Id = 1,
            Name= "Baton Rouge",
            RegionId= 4
        },
        new DesignStudio
        {
            Id = 2,
            Name= "Oklahoma City",
            RegionId= 4
        },
        new DesignStudio
        {
            Id = 3,
            Name= "Mobile",
            RegionId= 1
        },
        new DesignStudio
        {
            Id = 4,
            Name= "Jonesboro",
            RegionId= 4
        },
        new DesignStudio
        {
            Id = 5,
            Name= "Fort Wayne",
            RegionId= 2

        },
        new DesignStudio
        {
            Id = 6,
            Name= "Buffalo",
            RegionId = 2
        },
        new DesignStudio
        {

            Id = 7,
            Name = "Augusta",
            RegionId = 4

        },
        new DesignStudio
        {

            Id = 8,
            Name = "Albuquerque",
            RegionId = 5

        }
    };




    public UserAppTests()
    {
        var mockRepo = new Mock<IGenericRepository<User>>();

        var designStudioRepo = new Mock<IGenericRepository<DesignStudio>>(); //moq that goes to dsc statmen

        mockRepo.Setup(u => u.UpdateAsync(It.IsAny<User>()));

        mockRepo.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(() => user);

        //mockRepo.Setup(m => m.GetAllAsync()).

        mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(() => _users);

        //mockRepo.Setup(u => u.UpdateAsync(It.IsAny<User>())).ReturnsAsync(user);

        mockRepo.Setup(x => x.AddAsync(It.IsAny<User>())).Callback<User>(X => _users.Add(X)).ReturnsAsync(() => _users[0]);

        mockRepo.Setup(x => x.DeleteAsync(It.IsAny<int>())).Callback<int>(x =>
        {

            User deletedUser = null;

            foreach (User user in _users)
            {

                if (user.Id == x)
                {

                    deletedUser = user;
                }
            }
            _users.Remove(deletedUser);

        }).Returns(Task.CompletedTask);

        _app = new UserApp(mockRepo.Object);

        _designStudioApp = new DesignStudioApp(designStudioRepo.Object);


    }

    [Fact]

    public async void RemoveUser_Success()
    {
        // Arrange
        var initialCount = _app.GetUsers().Result.Count;

        // Act
        var deleteUser = _app.DeleteUser(_users[0].Email);
        var finalCount = _app.GetUsers().Result.Count;

        // Assert
        Assert.Equal(finalCount, (initialCount - 1));
    }

    [Fact]
    public void RemoveUser_Failure()
    {
        // Arrange
        var initialCount = _app.GetUsers().Result.Count;

        // Act
        var deleteUser = _app.DeleteUser(_users[0].Email);
        var finalCount = _app.GetUsers().Result.Count;

        // Assert
        Assert.NotEqual(initialCount, finalCount);
    }

    [Fact]

    public void GetUsers_Success()
    {

        // Arrange
        var expectedCount = 2;

        // Act        
        var repoCount = _app.GetUsers().Result.Count;
        var mockUsers = _app.GetUsers().Result;

        // Assert
        Assert.Equal(expectedCount, repoCount);
    }

    [Fact]
    public void CreateUser_Fail_DuplicateEntry()
    {
        // Act
        var expectedCount = 3;

        // Arrange
        var initialCount = (_app.GetUsers().Result.Count);

        _app.CreateUser(user);
        
        var finalCount = _app.GetUsers().Result.Count;

        // Assert
        Assert.NotEqual(initialCount, finalCount);

    }

    [Fact]

    public void CreateUser_Success()
    {
        // Arrange
        var expectedCount = 2;

        // Act
        var addUser = _app.CreateUser(_users[0]);

        // Assert 
        var finalCount = _app.GetUsers().Result.Count();

        Assert.Equal(expectedCount, finalCount);

    }

    [Fact]
    public void CreateUser_Failure()
    {
        // Arrange
        var wrongCount = 3;

        // Act
        var addUser = _app.CreateUser(_users[0]);

        // Assert 
        var finalCount = _app.GetUsers().Result.Count();

        Assert.NotEqual(wrongCount, finalCount);

    }

    [Fact]
    public void Validate_Failure()
    {


        // Arrange 
        var user = _app.GetUsers().Result[0];
        var expected = false;

        // Act
        var isValid = _app.Validate(user.Email, user.Password + "ff").Result;

        // Assert
        Assert.Equal(isValid, expected);
    }


    [Fact]
    public void Validate_Success()
    {


        // Arrange
        var credentials = _app.Validate(_users[0].Email, _users[0].Password);

        // Act
        var truecredentials = _app.Validate(_users[0].Email, _users[0].Password);

        // Assert
        Assert.Equal(credentials, truecredentials);
    }

    [Fact]

    public void UpdateUser_Success()
    {
        // Arrange
        var updated = _app.UpdateUser(_users[0]);

        // Act
        var userUpdate = _app.UpdateUser(_users[0]).Result;

        // Assert
        Assert.Equal(userUpdate, "Updated Successfully");

    }

    [Fact]
    public void GetUser_Success()
    {
        // Arrange
        var expectedId = 1;

        // Act
        var userId = _app.GetUser(_users[0].Id).Result;

        // Assert
        Assert.Equal(user, userId);
    }


}



