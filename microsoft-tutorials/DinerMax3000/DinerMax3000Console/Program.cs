using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerMax3000Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FoodMenu summerMenu = new FoodMenu();
            summerMenu.Name = "Summer menu";
            summerMenu.AddMenuItem("Salmon", "Fresh Norwegian Salmon with Sandefjord butter.", 25.50);
            summerMenu.AddMenuItem("Taco", "All Norwegians eat taco on Fridays.", 10);
            summerMenu.HospitalDirections = "Right around the corner of 5th street, Ask for Dr. Jones.";

            DrinkMenu outsideDrinks = new DrinkMenu();
            outsideDrinks.Disclaimer = "Do not drink and code.";
            outsideDrinks.AddMenuItem("Virgin Cuba Libre", "A classic.", 10);
            outsideDrinks.AddMenuItem("Screwdriver", "Makes you hammered.", 15);

            Order hungryGuestOrder = new Order();

            for (int x = 0; x <= summerMenu.items.Count-1; x++)
            {
                MenuItem currentItem = summerMenu.items[x];
                hungryGuestOrder.items.Add(currentItem);
            }

            foreach (MenuItem currentItem in outsideDrinks.items)
            {
                hungryGuestOrder.items.Add(currentItem);
            }

            Console.WriteLine("The total is:" + hungryGuestOrder.Total);
            Console.ReadKey();

            try
            {

                outsideDrinks.AddMenuItem("Himkok", "9 of 10 people recommend staying away from this d" +
                                                    "rink.", 0);
            }
            catch (Exception thrownException)
            {
                Console.WriteLine(thrownException.Message);
            }
        }
    }
}
