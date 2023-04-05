using CarProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Domain
{
    public class CarContext : DbContext, ICarContext
    {
        public CarContext() : base("name=CarDatabase")
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}
