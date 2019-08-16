﻿using System;
using learning.DomainObjects;
using learning.Entity;
using MediatR;
using Newtonsoft.Json.Linq;

namespace learning.Events
{
    public class RequestCreateCar : IRequest<CarCreated>
    {
        public Guid AggregateId { get; set; }
        public string CarDoorsWheelType { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string WheelType { get; set; }
        public string VehicleType { get; set; }
        public string Color { get; set; }
        public int CarDoors { get; set; }
        public bool Sunroof { get; set; }
        public string WindowType { get; set; }
    }

    public class CarCreated : Event, INotification
    {
        public override int Version { get => 1; }
        public override string EventName { get => "CarCreated"; }
        public Guid AggregateId { get; set; }
        public string CarDoorsWheelType { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string WheelType { get; set; }
        public string VehicleType { get; set; }
        public string Color { get; set; }
        public int CarDoors { get; set; }
        public bool Sunroof { get; set; }

        public static CarCreated From(Car car)
        {
            return new CarCreated()
            {
                AggregateId = car.Id,
                CarDoorsWheelType = car.CarDoorsWheelType,
                Make = car.Make,
                Model = car.Model,
                Year = car.Year,
                WheelType = car.WheelType,
                VehicleType = car.VehicleType,
                Color = car.Color,
                CarDoors = car.CarDoors,
                Sunroof = car.Sunroof
            };
        }

        public string WindowType { get; set; }
    }

    public class ChangeCarManufacture : Event, IRequest<Car>
    {
        public override int Version { get => 1; }
        public override string EventName { get => "CarManufactureChanged"; }
        public string CarDoorsWheelType { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
    }

    public class ChangeCarDescription : Event, IRequest<ChangeCarDescription>
    {
        public override int Version { get => 1; }
        public override string EventName { get => "CarDescriptionChanged"; }
        public string VehicleType { get; set; }
        public int CarDoors { get; set; }
        public string Color { get; set; }
    }

    public class ChangeCarFeatures : Event, IRequest<ChangeCarFeatures>
    {
        public override int Version { get => 1; }
        public override string EventName { get => "CarFeaturesChanged"; }
        public string CarDoorsWheelType { get; set; }
        public string WheelType { get; set; }
        public bool Sunroof { get; set; }
        public string WindowType { get; set; }
    }
}
