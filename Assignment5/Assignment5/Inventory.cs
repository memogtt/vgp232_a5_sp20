using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Inventory
    {
        //int slots;    //removed it from now, not clear what it will be used for
        List<Item> items;

        public Inventory(int slots)
        {
            items = new List<Item>(slots);
        }

        public void Add(Item item)
        {
            items.Add(item);
            Console.WriteLine("{0} added to inventory.", item.Name);
        }

        //removes the first instance that matches the item parameters passed
        public void Remove(Item item)
        {
            //code to remove all instances
            //List<int> toRemove = new List<int>();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name.Equals(item.Name) && items[i].Modifier == item.Modifier && items[i].IType == item.IType)
                {
                    //toRemove.Add(i);
                    Console.WriteLine("{0} removed from inventory.", item.Name);
                    items.RemoveAt(i);
                    break;
                }
            }

            //toRemove.Reverse();
            //foreach (int i in toRemove)
            //  items.RemoveAt(i);

        }


        public void ShowInventory()
        {
            foreach (Item item in items)
            {
                Console.WriteLine(item);
            }
        }

        public int GetInventorySize()
        {
            return items.Count;
        }
    }
}
