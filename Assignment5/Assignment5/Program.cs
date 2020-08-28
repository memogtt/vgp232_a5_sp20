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
            Console.WriteLine("Welcome to the Adventure of Assignment 5");

            Character myCharacter = new Character("Bob", RaceCatagory.Elf, 100);

            myCharacter.TakeDamage(10);

            myCharacter.RestoreHealth(10);

            Console.WriteLine("The game has ended with {0} with {1} health", myCharacter.Name, myCharacter.HealthPoints);
			
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
