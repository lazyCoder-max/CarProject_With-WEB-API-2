using CarProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarProject.DataAccess.Repository
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(int id);
        void InsertCarAsync(Car car);
        Task UpdateCarAsync(Car car);
    }
}