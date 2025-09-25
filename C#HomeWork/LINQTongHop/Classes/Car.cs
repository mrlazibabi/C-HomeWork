using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTongHop.Classes
{
    public class Car
    {
        public int CarID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public Engine Engine { get; set; }
        public Dimensions Dimensions { get; set; }
        public Weight Weight { get; set; }
        public Performance Performance { get; set; }
        public double FuelCapacity { get; set; }
        public Mileage Mileage { get; set; }
        public string ColorsAvailable { get; set; }
        public Warranty Warranty { get; set; }
        public Owner Owner { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }
        public string ManufactureDate { get; set; }
        public string LastServiceDate { get; set; }
        public string PurchaseDate { get; set; }
    }
}
