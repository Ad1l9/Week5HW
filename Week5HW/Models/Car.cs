using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Week5HW.Interfaces;

namespace Week5HW.Models
{
    internal class Car : IVehicle
    {
        public Car(double fuel = 20, double fuelConsumption = 10, double tankCapacity = 40)
        {
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }

        public static double MilAge = 0;
        public double Fuel { get; set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }

        public bool Drive(double kilometr)
        {
            if (kilometr > 0 && Fuel - (kilometr * (FuelConsumption / 100)) >= 0) return true;
            else return false;
        }

        public bool Refuel(double amount)
        {
            if (amount + Fuel > TankCapacity) return false;
            else return true;
        }

    }
}
