using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmGame.Models
{
    public class Item
    {
        public string Name { get; }
        public int MaxStack { get; }

        public Item(string name, int maxStack = 20)
        {
            Name = name;
            MaxStack = maxStack;
        }
    }

}
