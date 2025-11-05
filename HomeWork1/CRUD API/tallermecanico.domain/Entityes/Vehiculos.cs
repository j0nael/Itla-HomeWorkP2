using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace tallermecanico.domain.Entityes
{
    public class Vehicle
    {
        [Key]
        
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        public int CustomerId { get; set; }

        public int? SellerId { get; set; }

        public int? InvoiceId { get; set; }

        public Invoice? Invoice { get; set; }

        public Customer? Customer { get; set; }

        public Seller? Seller { get; set; }

        public List<Repair>? Repairs { get; set; }

        public Vehicle() { }

        public Vehicle(int vehicleId,string licensePlate, string brand, string model, string color, int year,int customerId)
        {
            VehicleId = vehicleId;
            LicensePlate = licensePlate;
            Brand = brand;
            Model = model;
            Color = color;
            Year = year;
            CustomerId = customerId;

        }
    }
}