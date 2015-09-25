using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingInheritace
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.Make = "BMW";
            myCar.Model = "745li";
            myCar.Colour = "Black";
            myCar.Year = 2005;

            printCarDetails(myCar);

            Truck myTruck = new Truck();

            myTruck.Make = "Ford";
            myTruck.Model = "F950";
            myTruck.Year = 2006;
            myTruck.Colour = "Black";
            myTruck.TowingCapacity = 1200;

            printCarDetails(myTruck);


            Console.ReadLine();
              

        }



        private static void printCarDetails(Car car) 
        {
            Console.WriteLine("Here are the Car's details: {0}",
                car.FormatMe());
        }
    }

    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Colour { get; set; }
        

        public string FormatMe()
        {
            return String.Format("{0} - {1} - {2} - {3}",
                this.Make,
                this.Model,
                this.Colour,
                this.Year);
                
        }
    }

    class Truck : Car
    {
        public int TowingCapacity { get; set; }
    }

}
