using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarPark;
public class program
{
    public static void Main()
    {
        ParkingUi parkingUi = new ParkingUi();
        parkingUi.Run("Tel Aviv", "Hamasger", 12, 240643,4 , 12.5);
    }
}