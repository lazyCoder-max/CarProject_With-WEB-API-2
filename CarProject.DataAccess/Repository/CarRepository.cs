using CarProject.Domain;
using CarProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.DataAccess.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly List<Car> _cars;

        public CarRepository()
        {
            _cars = new List<Car>();
        }

        public  void InsertCarAsync(Car car)
        {
            using (var s = new CarContext())
            {
                s.Cars.Add(car);
                s.SaveChanges();
            }
        }

        public async Task UpdateCarAsync(Car car)
        {
            using (var s = new CarContext())
            {
                var existingCar = s.Cars.FirstOrDefault(c => c.Id == car.Id);
                if (existingCar != null)
                {
                    existingCar.Name = car.Name;
                    existingCar.Color = car.Color;
                    existingCar.YearMade = car.YearMade;
                    s.SaveChanges();
                }
            }
            
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return _cars;
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            using (var s = new CarContext())
            {
               return  s.Cars.FirstOrDefault(c => c.Id == id);
            }
        }
    }

}
