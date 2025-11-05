using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmGame.Models;

namespace FarmGame
{
    public class Field : Building
    {
        public List<Crop> Crops { get; set; } = new List<Crop>();
       

        public Field(string name, int cost, int expReward, int maxSlots)
            : base("Small Field 1",1,0,25,5,TimeSpan.FromSeconds(0),false)
        {
            
        }

        public void PlantCrop(Crop crop, int availableSeeds, int seedsToPlant)
        {
            if (Crops.Count >= Capacity)
            {
                Console.WriteLine("Поле заповнене!");
                return;
            }

            var result = crop.Plant(availableSeeds, seedsToPlant);
            Console.WriteLine(result.message);

            if (result.success)
            {
                Crops.Add(crop);
            }
        }

        public void Harvest(Player player)
        {
            var harvested = new List<Crop>();

            foreach (var crop in Crops)
            {
                if (crop.CheckGrowth())
                {
                    player.AddExp(crop.ExpPerHarvest);
                    harvested.Add(crop);
                }
            }

            foreach (var crop in harvested)
                Crops.Remove(crop);
        }
    }
}
