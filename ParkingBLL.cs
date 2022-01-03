using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
internal class ParkingBLL
    {
        private static ParkingDAL Dal = new ParkingDAL();
        public void SetPark(string city, string street, int index, int compeny, int capasty, double price)
        {
            Dal.SetPark(city, street, index, compeny, capasty, price);
        }                   
        public string GetAllCars() 
        {
            return Dal.GetAllCars(); 
        }
        public bool AddCar(string licenceNumber, CarType type, ColorType color)
        {
            return Dal.AddCar(licenceNumber, type, color);
        }
        public int FindCar(string PlateNumber)
        {
            return Dal.FindCar(PlateNumber);
        }

        public int FreeSpace()
        {
            return Dal.FreeSpace();
        }

        public bool RemoveCar(string PlateNumber)
        {
            return Dal.RemoveCar(PlateNumber);
        }

        public double GetCost(string PlateNumber)
        {
            return Dal.GetCost(PlateNumber);
        }

        


    }




}
