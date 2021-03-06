﻿using Moq;
using SpacePort.Models;
using System.Collections.Generic;
using Moq.EntityFrameworkCore;
using Xunit;
using SpacePort.Controllers;
using Microsoft.Extensions.Logging;
using SpacePort.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using SpacePort.Services.Interfaces;
using System.Threading.Tasks;

namespace SpacePort.Tests.ControllerTests
{
    public class DriverControllerTests
    {

        [Fact]
        public async void GetAll_ifAnyExist_ReturnTrue()
        {
            //Arrange
            var mockContext = new Mock<DataContext>();
            mockContext.Setup(x => x.Drivers).ReturnsDbSet(GetDriver());

            var logger = Mock.Of<ILogger<DriverRepository>>();
            var driverRepo = new DriverRepository(mockContext.Object, logger);

            var driverController = new DriverController(driverRepo);

            //Act
            var result = await driverController.GetAll();
            var contentResult = result.Result as OkObjectResult;
            var resultDriver = contentResult.Value as Driver[];

            //Assert
            Assert.True(resultDriver.Length > 0);
        }

        [Fact]
        public async void GetDriverById_IfExist_ReturnTrue()
        {

            //Arrange
            var mockContext = new Mock<DataContext>();
            mockContext.Setup(x => x.Drivers).ReturnsDbSet(GetDriver());

            var logger = Mock.Of<ILogger<DriverRepository>>();
            var driverRepo = new DriverRepository(mockContext.Object, logger);

            var driverController = new DriverController(driverRepo);

            //Act
            var result = await driverController.GetDriverById(1);
            var contentResult = result.Result as OkObjectResult;
            var resultDriver = contentResult.Value as Driver;

            //Assert
            Assert.NotNull(resultDriver);
        }

        [Fact]
        public async void CreateDriver_IfCreateDriverNotInStarWars_Expected204StatusCode()
        {
            //Arrange
            var driverRepo = new Mock<IDriverRepository>();
            driverRepo.Setup(x => x.Save()).Returns(Task.FromResult(true));

            var driverController = new DriverController(driverRepo.Object);

            //Act
            var createdResult = await driverController.CreateDriver(new Driver
            {
                DriverId = 2,
                Name = "Oskar"
            });
            var contentResult = createdResult.Result as NoContentResult;

            //Assert
            Assert.Equal(204, contentResult.StatusCode);
        }

        [Fact]
        public async void CreateDriver_IfCreateDriverInStarWars_Expected201StatusCode()
        {
            //Arrange
            var driverRepo = new Mock<IDriverRepository>();
            driverRepo.Setup(x => x.Save()).Returns(Task.FromResult(true));

            var driverController = new DriverController(driverRepo.Object);

            //Act
            var createdResult = await driverController.CreateDriver(new Driver
            {
                DriverId = 3,
                Name = "C-3PO"
            });
            var contentResult = createdResult.Result as CreatedResult;

            //Assert
            Assert.Equal(201, contentResult.StatusCode);
        }

        public List<Driver> GetDriver()
        {
            return new List<Driver>
            {
                new Driver
                {
                    DriverId = 1,
                    Name = "Luke"
                }
            };
        }
    }
}
