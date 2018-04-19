
namespace CarDealerApp.Services
{
    using System;
    using System.Collections.Generic;
    using CarDealerApp.Models;
    using CarDealer.Data;
    using System.Linq;

    public class CarsService
    {
        public IEnumerable<CarsViewModel> GetCars(string make)
        {
            using (var context = new CarDealerContext())
            {
                var cars = context.Cars
                    .Where(c=> c.Make == make)
                    .OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TravelledDistance)
                    .Select(c=> new CarsViewModel()
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    })
                    .ToList();

                return cars;
            }
        }
    }
}