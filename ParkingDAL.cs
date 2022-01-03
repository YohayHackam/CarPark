using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    internal class ParkingDAL
    {
        private Parking park =new Parking();
        private List<Car> cars=new List<Car>();
        
        public void SetPark(string city, string street ,int number, int compeny , int capasty , Double price)
        { park.SetData(city, street, number, compeny, capasty,price );}
        public string GetPark()   { return park.GetData(); }
        public int  FreeSpace() { return park.Capasty-cars.Count; }
        public bool AddCar(string PlateNumber,CarType type, ColorType color)
        { 
            Car car = new Car();
            car.SetCar(PlateNumber, type, color, park.Price);
            if (FindCar(PlateNumber)==-1 && cars.Count < park.Capasty)
            {
                cars.Add(car);
                return true;
            }
            return false;
        }

        public int FindCar(string PlateNumber)
        {
            if (!cars.Exists(x => x.PlateNumber.Equals(PlateNumber))) return -1;
            return cars.FindIndex(x => x.PlateNumber.Equals(PlateNumber));
        }
        public double GetCost(string PlateNumber)
        {

            int index = FindCar(PlateNumber);
            if (index == -1) return -1;
            return cars[index].CalculatePayment();

        }
        public bool RemoveCar(string PlateNumber)
        {
            if (FindCar(PlateNumber)!=-1)
            {
                cars.RemoveAt(FindCar(PlateNumber));
                return true;
            }
            return false;
        }
        public string GetAllCars()
        {
            StringBuilder CarReport = new StringBuilder();
            if (cars.Count == 0) return "Parkinglot is Empty";
            foreach (Car car in this.cars)
            {
                car.CalculatePayment();
                CarReport.AppendLine(car.GetCar());         
            }
            return CarReport.ToString();
        }

    }
}
