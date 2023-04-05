using CarProject.Domain.Entities;
using System.Data.Entity;

namespace CarProject.Domain
{
    public interface ICarContext
    {
        DbSet<Car> Cars { get; set; }
    }
}