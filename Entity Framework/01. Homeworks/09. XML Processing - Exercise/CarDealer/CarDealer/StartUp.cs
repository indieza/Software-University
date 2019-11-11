namespace CarDealer
{
    using System;
    using System.Text;
    using System.Linq;
    using CarDealer.Dtos.Import;
    using System.IO;
    using CarDealer.Data;
    using System.Collections.Generic;
    using CarDealer.Models;
    using AutoMapper;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<CarDealerProfile>();
            });

            var context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var suppliers = File.ReadAllText(@"D:\Documents\GitHub\Software-University\Entity Framework\01. Homeworks\09. XML Processing - Exercise\CarDealer\CarDealer\Datasets\suppliers.xml");

            //var parts = File.ReadAllText(@"D:\Documents\GitHub\Software-University\Entity Framework\01. Homeworks\09. XML Processing - Exercise\CarDealer\CarDealer\Datasets\parts.xml");

            //var cars = File.ReadAllText(@"D:\Documents\GitHub\Software-University\Entity Framework\01. Homeworks\09. XML Processing - Exercise\CarDealer\CarDealer\Datasets\cars.xml");

            //var customers = File.ReadAllText(@"D:\Documents\GitHub\Software-University\Entity Framework\01. Homeworks\09. XML Processing - Exercise\CarDealer\CarDealer\Datasets\customers.xml");

            //var sales = File.ReadAllText(@"D:\Documents\GitHub\Software-University\Entity Framework\01. Homeworks\09. XML Processing - Exercise\CarDealer\CarDealer\Datasets\sales.xml");

            //Console.WriteLine(ImportSuppliers(context, suppliers));
            //Console.WriteLine(ImportParts(context, parts));
            //Console.WriteLine(ImportCars(context, cars));
            //Console.WriteLine(ImportCustomers(context, customers));
            //Console.WriteLine(ImportSales(context, sales));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer =
                new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));
            var suppliersDto = (ImportSupplierDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Supplier> suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));
            var partsDto = (ImportPartDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Part> parts = new List<Part>();

            foreach (var partDto in partsDto)
            {
                var supplier = context.Suppliers.Find(partDto.SupplierId);

                if (supplier != null)
                {
                    var part = Mapper.Map<Part>(partDto);
                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));
            var carsDto = (ImportCarDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Car> cars = new List<Car>();

            foreach (var carDto in carsDto)
            {
                var car = Mapper.Map<Car>(carDto);

                context.Cars.Add(car);

                foreach (var part in carDto.Parts.PartsId)
                {
                    if (car.PartCars
                        .FirstOrDefault(p => p.PartId == part.PartId) == null &&
                        context.Parts.Find(part.PartId) != null)
                    {
                        var partCar = new PartCar
                        {
                            CarId = car.Id,
                            PartId = part.PartId
                        };

                        car.PartCars.Add(partCar);
                    }
                }

                cars.Add(car);
            }

            int count = context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer =
                new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));
            var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Customer> customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                var customer = Mapper.Map<Customer>(customerDto);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));
            var salesDto = (ImportSaleDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Sale> sales = new List<Sale>();

            foreach (var saleDto in salesDto)
            {
                if (context.Cars.Find(saleDto.CarId) != null)
                {
                    var sale = Mapper.Map<Sale>(saleDto);
                    sales.Add(sale);
                }
            }

            context.Sales.AddRange(sales);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }
    }
}