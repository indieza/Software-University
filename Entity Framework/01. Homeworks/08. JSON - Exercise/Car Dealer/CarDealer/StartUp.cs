using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
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

            Console.WriteLine(ImportCars(context, file));
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
    }
}