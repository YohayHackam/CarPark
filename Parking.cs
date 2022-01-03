using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



internal class Parking
{
    public string City { get; private set; }
    public string Street { get; private set; }
    public int Number { get; private set; }
    public int Compeny { get; private set; }
    public int Capasty { get; private set; }
    public double Price { get; set; }

    public void SetData(string city, string street,int index, int compeny, int capasty ,double price)
    {
        this.City = city;
        this.Street = street;
        this.Number = index;
        this.Price = price;
        this.Compeny = compeny;
        this.Capasty = capasty;
    }
    public string GetData()
    { return $"city:{this.City} ,street:{this.Street} ,number:{this.Number} ,compeny:{this.Price} ,capasty:{this.Compeny} ,price:{this.Capasty} "; }
}
 
    
