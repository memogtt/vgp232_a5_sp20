using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public enum RaceCatagory { Dwarf, Elf, Orc, Human, Undead }

    public class Character
    {
        public int HealthPoints { get; set; }
        public RaceCatagory Race { get; set; }
        public string Name { get; set; }

        public Character()
        {
            ; // Default constructor.
        }

        public Character(string name, RaceCatagory race, int hp)
        {
            HealthPoints = hp;
            Race = race;
            Name = name;
        }

        public void TakeDamage(int damage)
        {
            HealthPoints -= damage;
            Console.WriteLine("{0} has taken {1} damage and has a total of {2} left.", Name, damage, HealthPoints);
        }

        public void RestoreHealth(int amount)
        {
            HealthPoints += amount;
            Console.WriteLine("{0} has restored {1} hp and has a total of {2}.", Name, amount, HealthPoints);
        }
    }
}
