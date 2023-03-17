using Application;
using Application.Interfaces;
using Application.Persistence;
using Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ApiUnitTests;
public class AvailabilityAppTests
{
    IAvailabilityApp _app = null;

    List<Availability> _availabilities = new List<Availability>()
    {
        new Availability
        {
            Id = 1,
            startTime= "11:00 am",
            EndTime= "12:00 pm",
            DayOfTheWeek= 1
        },
        new Availability
        {
            Id = 2,
            startTime= "1:30 pm",
            EndTime= "3:00 pm",
            DayOfTheWeek= 2
        },
        new Availability
        {
            Id = 3,
            startTime= "9:00 am",
            EndTime= "11:00 am",
            DayOfTheWeek = 3
        }
    };

    Availability newAvailability = new Availability
    {
        Id = 4,
        startTime = "12:30 pm",
        EndTime = "2:00 pm",
        DayOfTheWeek = 4
    };

    UserAvailability newUserAvailability = new UserAvailability
    {
        Id = 3,
        AvailabilityId = 1,
        UserId = 1
    };

    List<UserAvailability> userAvailabilities = new List<UserAvailability>()
    {
        new UserAvailability
        {
            Id = 1,
            AvailabilityId = 1,
            UserId = 1
        },
        new UserAvailability
        {
            Id = 2,
            AvailabilityId = 2,
            UserId = 2
        },
    };

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

    public AvailabilityAppTests()
    {

        var userRepo = new Mock<IGenericRepository<User>>();

        var designStudioRepo = new Mock<IGenericRepository<DesignStudio>>(); 

        userRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(() => _users);

        userRepo.Setup(x => x.AddAsync(It.IsAny<User>())).Callback<User>(X => _users.Add(X)).ReturnsAsync(() => _users[0]);

        userRepo.Setup(x => x.DeleteAsync(It.IsAny<int>())).Callback<int>(x =>
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

        var mockUserAvailabilityRepo = new Mock<IUserAvailabilityRepository>();


        mockUserAvailabilityRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(() => userAvailabilities);

        mockUserAvailabilityRepo.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(() => newUserAvailability);

        mockUserAvailabilityRepo.Setup(x => x.AddAsync(It.IsAny<UserAvailability>())).Callback<UserAvailability>(x => userAvailabilities.Add(x)).ReturnsAsync(() => newUserAvailability);

        mockUserAvailabilityRepo.Setup(x => x.DeleteAsync(It.IsAny<int>())).Callback<int>(x =>
        {
            UserAvailability deletedAvailability = null;
            foreach (UserAvailability availability in userAvailabilities)
            {
                if (availability.Id == x)
                {
                    deletedAvailability = availability;
                }
            }
            userAvailabilities.Remove(deletedAvailability);
        }).Returns(Task.CompletedTask);

        var mockAvailabilityRepo = new Mock<IGenericRepository<Availability>>();

        mockAvailabilityRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(() => _availabilities);

        mockAvailabilityRepo.Setup(u => u.UpdateAsync(It.IsAny<Availability>()));

        mockAvailabilityRepo.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(() => newAvailability); 

        mockAvailabilityRepo.Setup(x => x.AddAsync(It.IsAny<Availability>())).Callback<Availability>(x => _availabilities.Add(x)).ReturnsAsync(() => newAvailability);


        mockAvailabilityRepo.Setup(x => x.DeleteAsync(It.IsAny<int>())).Callback<int>(x =>
        {
            Availability deletedAvailability = null;
            foreach (Availability availability in _availabilities)
            {
                if (availability.Id == x)
                {
                    deletedAvailability = availability;
                }
            }
            _availabilities.Remove(deletedAvailability);
        }).Returns(Task.CompletedTask);

        _app = new AvailabilityApp(mockAvailabilityRepo.Object, userRepo.Object, mockUserAvailabilityRepo.Object);
    }

    [Fact]
    public void Availability_AddAvailability()
    {
        // Arrange
        var expectedResult = 4;

        // Act
        _app.CreateAvailability(newAvailability);

        // Assert
        var finalCount = _app.GetAvailabilities().Result.Count();

        Assert.Equal(expectedResult, finalCount);
    }

    [Fact]
    public void CreateAvailability_Success()
    {
        // Arrange
        var expectedCount = 3;

        // Act
        var addAvailability = _app.CreateAvailability(_availabilities[0]);

        // Assert
        var finalCount = _app.GetAvailabilities().Result.Count();

        Assert.Equal(expectedCount, finalCount);
    }

    [Fact]
    public void CreateAvailability_Failure()
    {
        // Arrange
        var wrongCount = 4;

        // Act
        var addAvailability = _app.CreateAvailability(_availabilities[0]);

        // Assert
        var finalCount = _app.GetAvailabilities().Result.Count();

        Assert.NotEqual(wrongCount, finalCount);
    }

    [Fact]
    public void CreateAvailability_Fail_DuplicateEntry()
    {
        // Arrange
        var expectedCount = 4;

        // Act
        var initialCount = (_app.GetAvailabilities().Result.Count);

        _app.CreateAvailability(newAvailability);

        var finalCount = _app.GetAvailabilities().Result.Count;

        // Assert
        Assert.NotEqual(initialCount, finalCount);
    }

    [Fact]
    public void RemoveAvailability_Success()
    {
        // Arrange
        var initialCount = _app.GetAvailabilities().Result.Count;

        // Act
        var deleteAvailability = _app.DeleteAvailability(_availabilities[0].Id);
        var finalCount = _app.GetAvailabilities().Result.Count;

        // Assert
        Assert.Equal(finalCount, (initialCount - 1));
    }

    [Fact]
    public void RemoveAvailability_Failure()
    {
        // Arrange
        var initialCount = _app.GetAvailabilities().Result.Count;

        // Act
        var deleteAvailability = _app.DeleteAvailability(_availabilities[0].Id);
        var finalCount = _app.GetAvailabilities().Result.Count;

        // Assert
        Assert.NotEqual(initialCount, finalCount);
    }

    [Fact]
    public void GetAvailability_Success()
    {
        // Arrange
        var expectedCount = 3;

        // Act
        var repoCount = _app.GetAvailabilities().Result.Count;
        var mockAvailabilities = _app.GetAvailabilities().Result;

        // Assert
        Assert.Equal(expectedCount, repoCount);
    }

    [Fact]
    public void GetAvailabilityId_Success()
    {
        // Arrange
        var expectedId = 1;
        
        // Act
        var repoId = _app.GetAvailabilityId(_availabilities[0].Id).Result;
        
        // Assert
        Assert.Equal(newAvailability, repoId);
    }

    [Fact]
    public void UpdateAvailability_Success()
    {
        // Arrange
        var updated = _app.UpdateAvailability(_availabilities[0]);

        // Act
        var availabilityUpdate = _app.UpdateAvailability(_availabilities[0]).Result.ToString();

        // Assert
        Assert.Equal(availabilityUpdate, "Updated Successfully");

    }
}