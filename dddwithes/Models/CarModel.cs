using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learning.DbContexts;
using learning.DomainObjects;
using learning.Entity;
using learning.Events;
using Newtonsoft.Json.Linq;

namespace learning.Model
{
    public class CarModel
    {
        private readonly CarContext car;

        public CarModel(CarContext carContext)
        {
            car = carContext;
        }

        public List<Car> GetAllCars() => car.Cars.ToList();

        public async Task<Car> ChangeCarManufacture(RequestChangeCarManufacture changeCarManufacture)
        {
            var ob = car.Cars.FirstOrDefault(c => c.Id == changeCarManufacture.AggregateId);
            ob.Model = changeCarManufacture.Model ?? ob.Model;
            ob.Make = changeCarManufacture.Make ?? ob.Make;
            ob.Year = changeCarManufacture.Year ?? ob.Year;
            car.Cars.Update(ob);
            await car.SaveChangesAsync();
            return ob;
        }

        public async Task<Car> CreateNewCarFromEvent(RequestCreateCar carEvent)
        {
            var entityCar = new Car();
            entityCar.Make = carEvent.Make;
            entityCar.Model = carEvent.Model;
            entityCar.Sunroof = carEvent.Sunroof;
            entityCar.VehicleType = carEvent.VehicleType;
            entityCar.WheelType = carEvent.WheelType;
            entityCar.WindowType = carEvent.WindowType;
            entityCar.Year = carEvent.Year;
            entityCar.CarDoors = carEvent.CarDoors;
            entityCar.CarDoorsWheelType = carEvent.CarDoorsWheelType;
            entityCar.Color = carEvent.Color;
            car.Cars.Add(entityCar);
            await car.SaveChangesAsync();
            return entityCar;
        }
    }
}