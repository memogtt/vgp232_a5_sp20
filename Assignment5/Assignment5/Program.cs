using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test of inventory");

            Inventory myInventory = new Inventory(3);

            Item potion = new Item("Potion", 2, ItemType.consumable);

            Console.WriteLine("Printing single Item");
            Console.WriteLine(potion);

            Item sword = new Item("Sword", 3, ItemType.equipment);

            myInventory.Add(potion);
            myInventory.Add(sword);

            Console.WriteLine("Print of inventory");
            myInventory.ShowInventory();

            myInventory.Remove(potion);

            Console.WriteLine("Print of inventory after removing potion");
            myInventory.ShowInventory();

        }
    }
}
