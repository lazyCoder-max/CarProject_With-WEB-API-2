using CarProject.Domain.Entities;
using CarProject.Service.Services;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace CarProject.API.Controllers
{

    [System.Web.Http.RoutePrefix("api/car")]
    public class CarController : ApiController
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("")]
        [SwaggerOperation("CreateCar")]
        [SwaggerResponse(HttpStatusCode.OK, "Car created", typeof(Car))]
        public IHttpActionResult CreateCar(Car car)
        {
            var createdCar = _carService.AddCarAsync(car);
            return Ok(createdCar);
        }

        [System.Web.Http.HttpPatch]
        [System.Web.Http.Route("{id:int}")]
        [SwaggerOperation("UpdateCar")]
        [SwaggerResponse(HttpStatusCode.OK, "Car updated", typeof(Car))]
        public IHttpActionResult UpdateCar(int id, [FromBody] Car carPatch)
        {
            var updatedCar = _carService.UpdateCarAsync(id, carPatch);
            return Ok(updatedCar);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("")]
        [SwaggerOperation("GetCarsByYear")]
        [SwaggerResponse(HttpStatusCode.OK, "List of cars", typeof(List<Car>))]
        public IHttpActionResult GetCarsByYear(int year)
        {
            var cars = _carService.GetCarsByYearAsync(year);
            return Ok(cars);
        }
    }

}