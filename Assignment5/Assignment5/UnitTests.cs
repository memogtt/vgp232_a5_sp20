using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    public class UnitTests
    {
        private Character character;
        private Item sword, potion;
        private Inventory inventory;


        [SetUp]
        public void SetUp()
        {
            character = new Character("Bob", RaceCatagory.Elf, 100);
            inventory = new Inventory(10);
            sword = new Item("Sword", 20, ItemType.equipment);
            potion = new Item("Potion", 10, ItemType.consumable);
        }

        [TearDown]
        public void CleanUp()
        {
            character = null;
            sword = null;
            potion = null;
            inventory = null;
        }

        // Character Unit Tests
        [Test]
        public void Character_Constructor()
        {
            Assert.AreEqual("Bob", character.Name);
            Assert.AreEqual(RaceCatagory.Elf, character.Race);
            Assert.AreEqual(100, character.HealthPoints);
        }

        [Test]
        public void Character_TakeDamage()
        {
            character.TakeDamage(20);
            Assert.AreEqual(80, character.HealthPoints);
        }

        [Test]
        public void Character_RestoreHealth()
        {
            character.RestoreHealth(30);
            Assert.AreEqual(130, character.HealthPoints);
        }

        // Item Unit Tests
        [Test]
        public void Item_Constructor()
        {
            Assert.AreEqual("Sword", sword.Name);
            Assert.AreEqual(20, sword.Modifier);
            Assert.AreEqual(ItemType.equipment, sword.IType);
        }


        // Inventory Unit Tests
        [Test]
        public void Inventory_Add()
        {
            Assert.AreEqual(0, inventory.GetInventorySize());
            inventory.Add(sword);
            Assert.AreEqual(1, inventory.GetInventorySize());
        }

        [Test]
        public void Inventory_Remove()
        {
            Assert.AreEqual(0, inventory.GetInventorySize());
            inventory.Add(sword);
            inventory.Add(potion);
            inventory.Remove(potion);
            Assert.AreEqual(1, inventory.GetInventorySize());
            inventory.Remove(sword);
            Assert.AreEqual(0, inventory.GetInventorySize());
        }
    }
}
