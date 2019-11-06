using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();
            //context.Database.EnsureCreated();

            var file = File.ReadAllText(@"D:\Documents\GitHub\Software-University\Entity Framework\01. Homeworks\08. JSON - Exercise\Car Dealer\CarDealer\Datasets\cars.json");

            Console.WriteLine(GetCarsWithTheirListOfParts(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<Supplier[]>(inputJson);
            context.Suppliers.AddRange(json);
            int count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => p.SupplierId <= 31);
            context.Parts.AddRange(json);
            int count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<Car[]>(inputJson);
            context.Cars.AddRange(json);
            int count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<Customer[]>(inputJson);
            context.Customers.AddRange(json);
            int count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<Sale[]>(inputJson);
            context.Sales.AddRange(json);
            int count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new ExportCustomerDto
                {
                    Name = $"{c.Name}",
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCrs = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportCarToyotaDto
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            var json = JsonConvert.SerializeObject(toyotaCrs, Formatting.Indented);

            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var items = context.Cars
                .Select(car =>
               new ExportCarDto
               {
                   Make = car.Make,
                   Model = car.Model,
                   TravelledDistance = car.TravelledDistance,
                   Parts = car.PartCars.Select(p => new ExportPartDto
                   {
                       Name = p.Part.Name,
                       Price = p.Part.Price
                   })
                   .ToList()
               })
                .ToList();

            var json = JsonConvert.SerializeObject(items, Formatting.Indented);

            return json;
        }
    }
}