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
            character = new Character("Bob", RaceCatagory.Elf, 100);

            Assert.AreEqual("Bob", character.Name);
            Assert.AreEqual(RaceCatagory.Elf, character.Race);
            Assert.AreEqual(100, character.HealthPoints);
        }

        [Test]
        public void Character_TakeDamage()
        {
            character = new Character("Bob", RaceCatagory.Elf, 100);

            character.TakeDamage(20);

            Assert.AreEqual(80, character.HealthPoints);
        }

        [Test]
        public void Character_RestoreHealth()
        {
            character = new Character("Bob", RaceCatagory.Elf, 100);

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


        /*
        [Test]
        public void PokeDex_GetHighestHP_Pokemon()
        {
            // 242 - Blissey, HP: 255
            pokedex.Clear();
            pokedex.Load(inputPathCSV);
            Pokemon actual = null;
            actual = pokedex.GetHighestHp();
            Assert.AreEqual("242", actual.Index);
            Assert.AreEqual("Blissey", actual.Name);
            Assert.AreEqual(255, actual.HP);
        }

        [Test]
        public void PokeDex_GetHighestAttack_Pokemon()
        {
            // 386.1 - Deoxys (A), Atk: 180
            pokedex.Clear();
            pokedex.Load(inputPathCSV);
            Pokemon actual = null;
            actual = pokedex.GetHighestAttack();
            Assert.AreEqual("386.1", actual.Index);
            Assert.AreEqual("Deoxys (A)", actual.Name);
            Assert.AreEqual(180, actual.Attack);
        }

        [Test]
        public void PokeDex_GetHighestSpeed_Pokemon()
        {
            // 386.3 - Deoxys (S), Spe: 180
            pokedex.Clear();
            pokedex.Load(inputPathCSV);
            Pokemon actual = null;
            actual = pokedex.GetHighestSpeed();
            Assert.AreEqual("386.3", actual.Index);
            Assert.AreEqual("Deoxys (S)", actual.Name);
            Assert.AreEqual(180, actual.Speed);
        }

        [Test]
        public void PokeDex_GetHighestSpecialDefense_Pokemon()
        {
            // 213 - Shuckle, SpD: 230
            pokedex.Clear();
            pokedex.Load(inputPathCSV);
            Pokemon actual = null;
            actual = pokedex.GetHighestSpecialDefense();
            Assert.AreEqual("213", actual.Index);
            Assert.AreEqual("Shuckle", actual.Name);
            Assert.AreEqual(230, actual.SpecialDefense);
        }

        [Test]
        public void PokeDex_FindHighestSpecialAttack_Pokemon()
        {
            // 386.1 - Deoxys (A), SpA: 180
            pokedex.Clear();
            pokedex.Load(inputPathCSV);
            Pokemon actual = null;
            actual = pokedex.GetHighestSpecialAttack();
            Assert.AreEqual("386.1", actual.Index);
            Assert.AreEqual("Deoxys (A)", actual.Name);
            Assert.AreEqual(180, actual.SpecialAttack);
        }


        [Test]
        public void PokeDex_LoadThatExistAndValid_True()
        {
            pokedex.Clear();

            Assert.IsTrue(pokedex.Load(inputPathCSV));
            Assert.AreEqual(663, pokedex.Count);
            // expect pokedex with count of 663.
        }

        [Test]
        public void PokeDex_LoadThatDoesNotExist_FalseAndEmpty()
        {
            // load returns false, expect an empty pokeDex
            pokedex.Clear();

            Assert.IsFalse(pokedex.Load("doesntexist.csv"));
            Assert.IsEmpty(pokedex);

        }

        [Test]
        public void PokeDex_SaveWithValuesCanLoad_TrueAndNotEmpty()
        {
            //save returns true, load returns true, and pokedex is not empty.
            pokedex.Clear();

            Assert.IsTrue(pokedex.Load(inputPathCSV));
            Assert.IsTrue(pokedex.Save(outputPathCSV));
            pokedex.Clear();
            Assert.IsTrue(pokedex.Load(outputPathCSV));
            Assert.IsNotEmpty(pokedex);
        }

        [Test]
        public void PokeDex_SaveEmpty_TrueAndEmpty()
        {
            // After saving an empty pokedex, load the file and expect pokedex to be empty.
            pokedex.Clear();
            Assert.IsTrue(pokedex.Save(outputPathCSV));
            Assert.IsTrue(pokedex.Load(outputPathCSV));
            Assert.IsTrue(pokedex.Count == 0);
        }

        // Pokemon Unit Tests
        [Test]
        public void Pokemon_TryParseValidLine_TruePropertiesSet()
        {
            // create a pokemon with the stats above set properly
            Pokemon expected = null;

            expected = new Pokemon()
            {
                Index = "1",
                Name = "Bulbasaur",
                HP = 45,
                Attack = 49,
                Defense = 49,
                SpecialAttack = 65,
                SpecialDefense = 65,
                Speed = 45,
                Total = 318,
                Type1 = Pokemon.PokemonType.Grass,
                Type2 = Pokemon.PokemonType.Poison
            };

            string line = "1,Bulbasaur,45,49,49,65,65,45,318,Grass,Poison";
            Pokemon actual = null;

            Assert.IsTrue(Pokemon.TryParse(line, out actual));
            Assert.AreEqual(expected.Index, actual.Index);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.HP, actual.HP);
            Assert.AreEqual(expected.Attack, actual.Attack);
            Assert.AreEqual(expected.Defense, actual.Defense);
            Assert.AreEqual(expected.SpecialAttack, actual.SpecialAttack);
            Assert.AreEqual(expected.SpecialDefense, actual.SpecialDefense);
            Assert.AreEqual(expected.Speed, actual.Speed);
            Assert.AreEqual(expected.Total, actual.Total);
            Assert.AreEqual(expected.Type1, actual.Type1);
            Assert.AreEqual(expected.Type2, actual.Type2);
        }

        [Test]
        public void Pokemon_TryParseInvalidLine_FalseNull()
        {
            //use "1,Bulbasaur,A,B,C,65,65", TryParse returns false, and pokemon is null.
            string line = "1,Bulbasaur,A,B,C,65,65";            //less than 11 elements
            string line2 = "1,Bulbasaur,A,B,C,65,65,2,3,2,2";   //eleven elements
            Pokemon actual = null;

            Assert.IsFalse(Pokemon.TryParse(line, out actual));
            Assert.IsNull(actual);

            Assert.IsFalse(Pokemon.TryParse(line2, out actual));
            Assert.IsNull(actual);
        }

        [Test]
        public void PokeDex_Load_Save_Load_ValidJson()
        {
            pokedex.Clear();
            Assert.IsTrue(pokedex.Load(inputPathCSV));
            Assert.IsTrue(pokedex.Save(outputPathJSON));
            Assert.IsTrue(pokedex.Load(outputPathJSON));
            Assert.IsTrue(pokedex.Count == 663);
        }

        [Test]
        public void PokeDex_Load_SaveAsJSON_Load_ValidJson()
        {
            pokedex.Clear();
            Assert.IsTrue(pokedex.Load(inputPathCSV));
            Assert.IsTrue(pokedex.SaveAsJSON(outputPathJSON));
            Assert.IsTrue(pokedex.Load(outputPathJSON));
            Assert.IsTrue(pokedex.Count == 663);
        }

        [Test]
        public void PokeDex_Load_SaveAsJSON_LoadJSON_ValidJson()
        {
            pokedex.Clear();
            Assert.IsTrue(pokedex.Load(inputPathCSV));
            Assert.IsTrue(pokedex.SaveAsJSON(outputPathJSON));
            Assert.IsTrue(pokedex.LoadJSON(outputPathJSON));
            Assert.IsTrue(pokedex.Count == 663);
        }

        [Test]
        public void PokeDex_Load_Save_LoadJSON_ValidJson()
        {
            pokedex.Clear();
            Assert.IsTrue(pokedex.Load(inputPathCSV));
            Assert.IsTrue(pokedex.Save(outputPathJSON));
            Assert.IsTrue(pokedex.LoadJSON(outputPathJSON));
            Assert.IsTrue(pokedex.Count == 663);
        }

        [Test]
        public void PokeDex_Load_Save_Load_ValidCsv()
        {
            pokedex.Clear();
            Assert.IsTrue(pokedex.Load(inputPathCSV));
            Assert.IsTrue(pokedex.Save(outputPathCSV));
            Assert.IsTrue(pokedex.Load(outputPathCSV));
            Assert.IsTrue(pokedex.Count == 663);
        }

        [Test]
        public void PokeDex_Load_SaveAsCSV_LoadCSV_ValidCsv()
        {
            pokedex.Clear();
            Assert.IsTrue(pokedex.Load(inputPathCSV));
            Assert.IsTrue(pokedex.SaveAsCSV(outputPathCSV));
            Assert.IsTrue(pokedex.LoadCSV(outputPathCSV));
            Assert.IsTrue(pokedex.Count == 663);
        }

        [Test]
        public void PokeDex_Load_Save_Load_ValidXml()
        {
            pokedex.Clear();
            Assert.IsTrue(pokedex.Load(inputPathCSV));
            Assert.IsTrue(pokedex.Save(outputPathXML));
            Assert.IsTrue(pokedex.Load(outputPathXML));
            Assert.IsTrue(pokedex.Count == 663);
        }

        [Test]
        public void PokeDex_Load_SaveAsXML_LoadXML_ValidXml()
        {
            pokedex.Clear();
            Assert.IsTrue(pokedex.Load(inputPathCSV));
            Assert.IsTrue(pokedex.SaveAsXML(outputPathXML));
            Assert.IsTrue(pokedex.LoadXML(outputPathXML));
            Assert.IsTrue(pokedex.Count == 663);
        }

        [Test]
        public void PokeDex_SaveEmpty_Load_ValidJson()
        {
            pokedex.Clear();
            Assert.IsTrue(pokedex.SaveAsJSON(outputPathJSON));
            Assert.IsTrue(pokedex.Load(outputPathJSON));
            Assert.IsTrue(pokedex.Count == 0);
        }

        [Test]
        public void PokeDex_SaveEmpty_Load_ValidCsv()
        {
            pokedex.Clear();
            Assert.IsTrue(pokedex.SaveAsCSV(outputPathCSV));
            Assert.IsTrue(pokedex.Load(outputPathCSV));
            Assert.IsTrue(pokedex.Count == 0);
        }

        [Test]
        public void PokeDex_SaveEmpty_Load_ValidXml()
        {
            pokedex.Clear();
            Assert.IsTrue(pokedex.SaveAsXML(outputPathXML));
            Assert.IsTrue(pokedex.Load(outputPathXML));
            Assert.IsTrue(pokedex.Count == 0);
        }

        [Test]
        public void PokeDex_Load_SaveJSON_LoadXML_InvalidXml()
        {
            pokedex.Clear();
            Assert.IsTrue(pokedex.Load(inputPathCSV));
            Assert.IsTrue(pokedex.SaveAsJSON(outputPathJSON));
            Assert.IsFalse(pokedex.LoadXML(outputPathJSON));
            Assert.IsTrue(pokedex.Count == 0);
        }

        [Test]
        public void PokeDex_Load_SaveXML_LoadJSON_InvalidJson()
        {
            pokedex.Clear();
            Assert.IsTrue(pokedex.Load(inputPathCSV));
            Assert.IsTrue(pokedex.SaveAsXML(outputPathXML));
            Assert.IsFalse(pokedex.LoadJSON(outputPathXML));
            Assert.IsTrue(pokedex.Count == 0);
        }

        [Test]
        public void PokeDex_ValidCsv_LoadXML_InvalidXml()
        {
            pokedex.Clear();
            Assert.IsFalse(pokedex.LoadXML(inputPathCSV));
            Assert.IsTrue(pokedex.Count == 0);
        }

        [Test]
        public void PokeDex_ValidCsv_LoadJSON_InvalidJson()
        {
            pokedex.Clear();
            Assert.IsFalse(pokedex.LoadJSON(inputPathCSV));
            Assert.IsTrue(pokedex.Count == 0);
        }
        */
    }
}
