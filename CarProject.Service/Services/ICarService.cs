using CarProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarProject.Service.Services
{
    public interface ICarService
    {
        Task AddCarAsync(Car car);
        Task<List<Car>> GetCarsByYearAsync(int year);
        Task UpdateCarAsync(int id, Car car);
        Task<List<Car>> GetAllCarsAsync();
        Task<Car> GetCarsByIdAsync(int id);
    }
}