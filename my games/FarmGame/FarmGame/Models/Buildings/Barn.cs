using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmGame.Models;

namespace FarmGame
{
    public class Barn : Building
    {
        
        public List<BarnSlot> Slots { get; private set; }

        public Barn(string name, int buildCost, int expReward)
            : base("Barn",1,0,25, 20, TimeSpan.FromSeconds(5),false)
        {
            
            Slots = new List<BarnSlot>();

            for (int i = 0; i < Capacity; i++)
                Slots.Add(new BarnSlot());
        }

        // Додати предмет у амбар
        public bool AddItem(Item item, int amount)
        {
            // шукаємо існуючий слот із тим самим предметом
            foreach (var slot in Slots)
            {
                if (!slot.IsEmpty && slot.Item.Name == item.Name && slot.Quantity < item.MaxStack)
                {
                    slot.AddItem(item, amount);
                    return true;
                }
            }

            // шукаємо порожній слот
            foreach (var slot in Slots)
            {
                if (slot.IsEmpty)
                {
                    slot.AddItem(item, amount);
                    return true;
                }
            }

            //Console.WriteLine("❌ Немає місця в амбарі!");
            return false;
        }

        // Покращення амбару
        public void Upgrade(Player player)
        {
            int upgradeCost = Level * 200; // наприклад, формула вартості покращення
            if (player.Coins >= upgradeCost)
            {
                player.Coins -= upgradeCost;
                Level++;
                Capacity += 10;
                for (int i = 0; i < 10; i++)
                    Slots.Add(new BarnSlot());
            }
            else
            {
                //Console.WriteLine("❌ Недостатньо монет для покращення амбару.");
            }
        }
    }

}
