using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Library
{
    public class Car
    {
        private bool VANID { get; set; }
        public string Model { get; set; }

        public string PlateNumber { get; set; }

        public enum VehicleType
        {
            sedan,
            hatchback
        }

        public VehicleType vehicleType { get; set; }

        public Car()
        {
            
        }

        public Car(bool vanid, string model, string plate_number, VehicleType vehicle_type)
        {
            this.VANID = vanid;
            this.Model = model;
            this.PlateNumber = plate_number; 
            this.vehicleType = vehicle_type;
        }

        public static Car Create(bool vanid, string model, string plate_number, VehicleType vehicle_type)
        {
            return new Car(vanid, model, plate_number, vehicle_type);
        }

        public void PrintObject()
        {
            Console.WriteLine($"vanid: {this.VANID}   model: {this.Model}   plate number: {this.PlateNumber}   vehicle type: {this.vehicleType}");
        }
    }
}
