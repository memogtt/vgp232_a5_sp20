using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public enum ItemType { consumable, key, equipment }

    public class Item
    {
        public string Name { get; set; }
        public int Modifier { get; set; }
        public ItemType IType { get; set; }

        public Item(string name, int modifier, ItemType type)
        {
            Name = name;
            Modifier = modifier;
            IType = type;
        }

        public override string ToString()
        {
            return string.Format("Item {0} has a modifier of {1} and is type {2}", Name, Modifier, IType);
        }
    }
}
