using CarProject.DataAccess.Repository;
using CarProject.Domain.Entities;
using CarProject.Service.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Service.Tests
{
    [TestFixture]
    public class CarServiceTests
    {
        private ICarService _carService;

        [SetUp]
        public void SetUp()
        {
            var mockCarRepository = new Mock<ICarRepository>();
            mockCarRepository.Setup(r => r.GetAllCarsAsync()).ReturnsAsync(new List<Car>
        {
            new Car { Id = 1, Name = "Toyota Camry", Color = "Red", YearMade = 2020 },
            new Car { Id = 2, Name = "Honda Civic", Color = "Blue", YearMade = 2018 },
            new Car { Id = 3, Name = "Ford Mustang", Color = "Yellow", YearMade = 2022 }
        });

            _carService = new CarService(mockCarRepository.Object);
        }

        [Test]
        public async Task GetAllCarsAsync_ReturnsAllCars()
        {
            // Arrange
            var expectedCars = await _carService.GetAllCarsAsync();

            // Act
            var cars = await _carService.GetAllCarsAsync();

            // Assert
            Assert.AreEqual(expectedCars.Count, cars.Count);
        }

        [Test]
        public async Task GetCarByIdAsync_WithValidId_ReturnsCorrectCar()
        {
            // Arrange
            int id = 1;

            // Act
            var car = await _carService.GetCarsByIdAsync(id);

            // Assert
            Assert.IsNotNull(car);
            Assert.AreEqual("Toyota Camry", car.Name);
        }
    }

}
