using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    internal class ParkingUi
    {
        enum Menu { AddCar, GetCost, RemoveCar ,Report};
        ParkingBLL bll = new ParkingBLL();
        public void Run(string city, string street, int index, int company,int capasty , double price)
        {
            bll.SetPark(city, street,index,company,capasty,price);
            while (true)
            {
                Menu UserSelection = UserMenuSelection();
                switch (UserSelection)
                {
                    case Menu.AddCar:

                        this.AddCar();
                        break;
                    case Menu.GetCost:
                        this.GetCost();
                        break;
                    case Menu.RemoveCar:
                        this.RemoveCar();
                        break;
                    case Menu.Report:
                        this.Report();
                        break;

                }
            }
        }
        private void Report()
        {
            Console.WriteLine(bll.GetAllCars());
        }

        private void RemoveCar()
        {
            string licenceNumber = string.Empty;
            ColorMessage("Search Car to Remove :\n============", ConsoleColor.Green);
            while (string.IsNullOrEmpty(licenceNumber))
            {
                Console.WriteLine("Please Enter car number plate :");
                licenceNumber = Console.ReadLine();
            }
            if (bll.FindCar(licenceNumber) == -1)
                ColorMessage("Sorry , Car not found\n=======================", ConsoleColor.DarkRed);
            else
            {
                if (bll.RemoveCar(licenceNumber))
                    ColorMessage("Car  secsefully Removed\n============", ConsoleColor.Green);
                else
                    ColorMessage("Something went wrong\n============", ConsoleColor.DarkRed);
            }
        }
        private void GetCost()
        {
            string licenceNumber = string.Empty;
            ColorMessage("Search Car for pricing:\n============", ConsoleColor.Green);
            while (string.IsNullOrEmpty(licenceNumber))
            {
                Console.WriteLine("Please Enter car number plate :");
                licenceNumber = Console.ReadLine();
            }
            if (bll.FindCar(licenceNumber) == -1)
                ColorMessage("Sorry , Car not found\n=======================", ConsoleColor.DarkRed);
            else
                //  Console.WriteLine($"Car licenceNumber: {licenceNumber} Total cost:{bll.GetCost(licenceNumber)}");
                ColorMessage($"Car licenceNumber: {licenceNumber} Total cost:{bll.GetCost(licenceNumber)}",ConsoleColor.Cyan);
        }

        private void AddCar()
        {
            string licenceNumber = string.Empty;
            CarType type;
            ColorType color;

            if (bll.FreeSpace()==0)
            {
                ColorMessage("Sorry , CarPark is full ..\n=======================", ConsoleColor.DarkRed);
            }
            else
            {
                ColorMessage("Adding Car :\n============", ConsoleColor.Green);
                while (string.IsNullOrEmpty(licenceNumber))
                {
                    Console.WriteLine("Please Enter car number plate :");
                    licenceNumber = Console.ReadLine();
                }
                type = TypeSelection();
                color = ColorSelection();
                if (bll.AddCar(licenceNumber, type, color))
                    ColorMessage("Car added secsefully\n============", ConsoleColor.Green);
                else
                    ColorMessage("Something went wrong\n============", ConsoleColor.DarkRed);


            }
        }

        private void ColorMessage(string massage, ConsoleColor color = ConsoleColor.White)
        {
            Console.Clear();
            Console.ForegroundColor = color;
            Console.WriteLine(massage);
            Console.ResetColor();
        }
        private Menu UserMenuSelection()
        {
            int i;
            Console.WriteLine("Select Option:");
            for (i = 0; i < Enum.GetValues(typeof(Menu)).Length; i++)
                Console.WriteLine("{0} : {1}", i + 1, (Menu)i);

            return (Menu)int.Parse(Console.ReadLine()) - 1;
        }
        private static CarType TypeSelection()
        {
            int i;
            Console.WriteLine("Please select vehicle Type :");
            for (i = 0; i < Enum.GetValues(typeof(CarType)).Length; i++)
                Console.WriteLine("{0} : {1}", i + 1, (CarType)i);

            return (CarType)int.Parse(Console.ReadLine()) - 1;
        }
        private static ColorType ColorSelection()
        {
            int i;
            Console.WriteLine("Please select vehicle Color :");
            for (i = 0; i < Enum.GetValues(typeof(ColorType)).Length; i++)
                Console.WriteLine("{0} : {1}", i + 1, (ColorType)i);

            return (ColorType)int.Parse(Console.ReadLine()) - 1;
        }
    }

}