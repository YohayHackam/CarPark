using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarPark
{
    public enum CarType { Other, Honda, Mitzubishi, Suzuki, Skoda };
    public enum ColorType { Other, Black, White, Red, Green, Blue };
    internal class Car
    {
        public string PlateNumber { get; private set; }
        public ColorType Color { get; set; }
        public CarType Type { get; set; }
        public DateTime EnteryTime { get; private set; }
        public DateTime ExitTime { get; private set; }
        public Double Cost { get; set; }
        public Double Payment { get; private set; }

        public void SetCar(string PlateNumber, CarType Type, ColorType Color, Double Cost)
        {
            this.PlateNumber = PlateNumber;
            this.Color = Color;
            this.Type = Type;
            this.Cost = Cost;
            this.EnteryTime = DateTime.Now;
        }
        public Double CalculatePayment()
        {
            TimeSpan span = (this.ExitTime = DateTime.Now) - this.EnteryTime;
            this.Payment = span.Hours * this.Cost;
            this.Payment += (span.Minutes > 0) ? this.Cost : 0;
            return this.Payment;
        }

        public string GetCar()
        {
            return $"PlateNumber:{this.PlateNumber} ,Type:{this.Type} ,Color:{this.Color} ,EnteryTime:{this.EnteryTime} ,ExitTime:{this.ExitTime} ,Hour Cost:{this.Cost} ,Total Payment:{this.Payment} ";
        }

    }
}