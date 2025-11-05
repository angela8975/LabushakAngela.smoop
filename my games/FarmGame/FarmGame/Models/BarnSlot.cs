using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmGame.Models
{
    public class BarnSlot
    {
        public Item Item { get; private set; }
        public int Quantity { get; private set; }

        public bool IsEmpty => Item == null;

        public bool AddItem(Item item, int amount)
        {
            if (IsEmpty)
            {
                Item = item;
                Quantity = Math.Min(amount, item.MaxStack);
                return true;
            }
            else if (Item.Name == item.Name)
            {
                Quantity = Math.Min(Quantity + amount, item.MaxStack);
                return true;
            }
            else
            {
                Console.WriteLine("❌ Слот зайнятий іншим предметом!");
                return false;
            }
        }


        public void Clear()
        {
            Item = null;
            Quantity = 0;
        }
    }
}
