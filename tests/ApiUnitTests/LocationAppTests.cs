using Application;
using Application.Interfaces;
using Application.Persistence;
using Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiUnitTests;
public class LocationAppTests
{
    IRegionApp _regionapp = null;

    IDesignStudioApp _designStudioApp = null;

    List<Region> _regions = new List<Region>()
    {
        new Region
        {
            Id = 1,
            Name = "South-East"
        },
        new Region
        {
            Id = 2,
            Name = "North-East"
        },
        new Region
        {
            Id = 3,
            Name = "Central"
        },
        new Region
        {
            Id = 4,
            Name = "South-East"
        },
        new Region
        {
            Id = 5,
            Name = "West"
        }
    };

    Region newRegion = new Region()
    {
        Id = 55,
        Name = "WestSide"

    };

    DesignStudio newDesignStudio = new DesignStudio()
    {
        Id = 8,
        Name = "Phoneix",
        RegionId = 4
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

    public LocationAppTests()
    {
        var regionRepo = new Mock<IGenericRepository<Region>>();

        var designStudioRepo = new Mock<IGenericRepository<DesignStudio>>();

        regionRepo.Setup(x => x.AddAsync(It.IsAny<Region>())).Callback<Region>
            (x => _regions.Add(x)).ReturnsAsync(() => _regions[0]); 

        regionRepo.Setup(u => u.UpdateAsync(It.IsAny<Region>())); 

        regionRepo.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(() => newRegion);

        designStudioRepo.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(() => newDesignStudio);

        regionRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(() => _regions); 

        designStudioRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(() => _designStudios); 

        designStudioRepo.Setup(x => x.AddAsync(It.IsAny<DesignStudio>())).
            Callback<DesignStudio>(x => _designStudios.Add(x)).ReturnsAsync(() => _designStudios[0]);

        regionRepo.Setup(x => x.DeleteAsync(It.IsAny<int>())).Callback<int>(x =>
        {

            Region deletedRegion = null;

            foreach (Region region in _regions)
            {

                if (region.Id == x)
                {

                    deletedRegion = region;
                }
            }
            _regions.Remove(deletedRegion);

        }).Returns(Task.CompletedTask);

        designStudioRepo.Setup(x => x.DeleteAsync(It.IsAny<int>())).Callback<int>(x =>
        {

            DesignStudio deletedStudio = null;

            foreach (DesignStudio designStudio in _designStudios)
            {

                if (designStudio.Id == x)
                {

                    deletedStudio = designStudio;
                }
            }
            _designStudios.Remove(deletedStudio);

        }).Returns(Task.CompletedTask);


        _regionapp = new RegionApp(regionRepo.Object);


        _designStudioApp = new DesignStudioApp(designStudioRepo.Object);

    }

    [Fact]

    public void GetRegions_Success()
    {

        // Arrange
        var expectedCount = 5;

        // Act        
        var repoCount = ((IApp<Region>)_regionapp).GetAll().Result.Count;
        var mockRegion = ((IApp<Region>)_regionapp).GetAll().Result;

        // Assert
        Assert.Equal(expectedCount, repoCount);
    }

    [Fact]

    public void CreateRegion_Success()
    {
        // Arrange
        var expectedCount = 5;

        // Act
        var addRegion = ((IApp<Region>)_regionapp).Create(_regions[0]);

        // Assert 
        var finalCount = ((IApp<Region>)_regionapp).GetAll().Result.Count();

        Assert.Equal(expectedCount, finalCount);

    }

    [Fact]

    public void CreateDesignCenter_Success()
    {
        // Arrange
        var expectedCount = 8;

        // Act
        var addDesignCenter = ((IApp<DesignStudio>)_designStudioApp).Create(_designStudios[0]);

        // Assert 
        var finalCount = ((IApp<DesignStudio>)_designStudioApp).GetAll().Result.Count();

        Assert.Equal(expectedCount, finalCount);

    }

    [Fact]

    public void GetDesignCenters_Success()
    {

        // Arrange
        var expectedCount = 8;

        // Act        
        var designCount = ((IApp<DesignStudio>)_designStudioApp).GetAll().Result.Count;
        var mockDesignCenter = ((IApp<DesignStudio>)_designStudioApp).GetAll().Result;

        // Assert
        Assert.Equal(expectedCount, designCount);
    }

    [Fact]
    public void RemoveRegion_Failure()
    {
        // Arrange
        var initialCount = ((IApp<Region>)_regionapp).GetAll().Result.Count;

        // Act
        var deleteRegion = ((IApp<Region>)_regionapp).Delete(_regions[0].Id);
        var finalCount = ((IApp<Region>)_regionapp).GetAll().Result.Count;

        // Assert
        Assert.NotEqual(initialCount, finalCount);
    }

    [Fact]
    public void RemoveDesignStudio_Failure()
    {
        // Arrange
        var initialCount = ((IApp<DesignStudio>)_designStudioApp).GetAll().Result.Count;

        // Act
        var deleteRegion = ((IApp<DesignStudio>)_designStudioApp).Delete(_designStudios[0].Id);
        var finalCount = ((IApp<DesignStudio>)_designStudioApp).GetAll().Result.Count;

        // Assert
        Assert.NotEqual(initialCount, finalCount);
    }

    [Fact]
    public void RemoveDesignStudio_Success()
    {
        // Arrange
        var initialCount = ((IApp<DesignStudio>)_designStudioApp).GetAll().Result.Count;

        // Act
        var deleteRegion = ((IApp<DesignStudio>)_designStudioApp).Delete(_designStudios[0].Id);
        var finalCount = ((IApp<DesignStudio>)_designStudioApp).GetAll().Result.Count;

        // Assert
        Assert.Equal(finalCount, (initialCount - 1));
    }

    [Fact]
    public void RemoveRegion_Success()
    {
        // Arrange
        var initialCount = ((IApp<Region>)_regionapp).GetAll().Result.Count;

        // Act
        var deleteRegion = ((IApp<Region>)_regionapp).Delete(_regions[0].Id);
        var finalCount = ((IApp<Region>)_regionapp).GetAll().Result.Count;

        // Assert
        Assert.Equal(finalCount, (initialCount - 1));
    }

    [Fact]

    public void UpdateRegion_Success()
    {
        // Arrange
        var updated = ((IApp<Region>)_regionapp).Update(_regions[0]);

        // Act
        var regionUpdate = ((IApp<Region>)_regionapp).Update(_regions[0]).Result;

        // Assert
        Assert.Equal(regionUpdate, "Updated Successfully");

    }

    [Fact]

    public void UpdateDesignStudio_Success()
    {
        // Arrange
        var updated = ((IApp<DesignStudio>)_designStudioApp).Update(_designStudios[0]);

        // Act
        var designStudioUpdate = ((IApp<DesignStudio>)_designStudioApp).Update(_designStudios[0]).Result;

        // Assert
        Assert.Equal(designStudioUpdate, "Updated Successfully");

    }

    [Fact]
    public void GetRegion_Success()
    {
        // Arrange
        var expectedId = 1;

        // Act
        var repoId = ((IApp<Region>)_regionapp).Get(_regions[0].Id).Result;

        // Assert
        Assert.Equal(newRegion, repoId);
    }

    [Fact]
    public void GetDesignStudio_Success()
    {
        // Arrange
        var expectedId = 1;

        // Act
        var repoId = ((IApp<DesignStudio>)_designStudioApp).Get(_designStudios[0].Id).Result;

        // Assert
        Assert.Equal(newDesignStudio, repoId);
    }

}


