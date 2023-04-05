using CarProject.DataAccess.Repository;
using CarProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Service.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task AddCarAsync(Car car)
        {
             _carRepository.InsertCarAsync(car);
        }

        public async Task UpdateCarAsync(int id, Car car)
        {
            var existingCar = await _carRepository.GetCarByIdAsync(id);

            if (existingCar == null)
            {
                throw new Exception($"Car with id {id} not found");
            }

            existingCar.Name = car.Name;
            existingCar.Color = car.Color;
            existingCar.YearMade = car.YearMade;

            await _carRepository.UpdateCarAsync(existingCar);
        }

        public async Task<List<Car>> GetCarsByYearAsync(int year)
        {
            var cars = await _carRepository.GetAllCarsAsync();

            var carsByYear = cars.Where(c => c.YearMade == year).ToList();
            return carsByYear;
        }
        public async Task<Car> GetCarsByIdAsync(int id)
        {
            var cars = await _carRepository.GetCarByIdAsync(id);
            return cars;
        }
        public async Task<List<Car>> GetAllCarsAsync()
        {
            var cars = await _carRepository.GetAllCarsAsync();

            return cars;
        }
    }

}
