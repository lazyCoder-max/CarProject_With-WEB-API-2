using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Domain.Entities
{
    public class Car : ICar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int YearMade { get; set; }
    }
}
