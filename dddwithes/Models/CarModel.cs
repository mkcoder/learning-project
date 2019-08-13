using System;
using System.Collections.Generic;
using System.Linq;
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

        public Car ChangeCarManufacture(ChangeCarManufacture changeCarManufacture)
        {
            var ob = car.Cars.FirstOrDefault(c => c.Id == changeCarManufacture.AggreagteId);
            ob.Model = changeCarManufacture.Model ?? ob.Model;
            ob.Make = changeCarManufacture.Make ?? ob.Make;
            ob.Year = changeCarManufacture.Year ?? ob.Year;
            car.Cars.Update(ob);
            car.SaveChanges();
            return ob;
        }

        public Car CreateNewCarFromEvent(CreateCar carEvent)
        {
            var entityCar = new Car();
            entityCar.Id = carEvent.AggreagteId;
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
            car.SaveChanges();
            return entityCar;
        }
    }
}