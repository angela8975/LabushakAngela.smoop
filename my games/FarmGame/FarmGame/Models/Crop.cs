using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmGame.Models
{
    public class Crop
    {
        public string Name { get; set; }
        public TimeSpan GrowTime { get; set; }
        public int ExpPerHarvest { get; set; }
        public int YieldPerSeed { get; set; } = 3;
        public bool IsGrown { get; private set; }
        public DateTime PlantedTime { get; private set; }
        public int SeedsPlanted { get; private set; }
        public int TotalYield => SeedsPlanted * YieldPerSeed;

        public Crop(string name, TimeSpan growTime, int expPerHarvest, int yieldPerSeed)
        {
            Name = name;
            GrowTime = growTime;
            ExpPerHarvest = expPerHarvest;
            YieldPerSeed = yieldPerSeed;
            IsGrown = false;
        }

        // Попытка посадить семена
        public (bool success, string message, int seedsUsed) Plant(int availableSeeds, int seedsToPlant)
        {
            if (seedsToPlant <= 0)
                return (false, "Нужно посадить хотя бы одно семечко.", 0);

            if (seedsToPlant > 5)
                return (false, "На малом поле можно посадить максимум 5 семян.", 0);

            if (availableSeeds < seedsToPlant)
                return (false, "Недостаточно семян для посадки.", 0);

            SeedsPlanted = seedsToPlant;
            PlantedTime = DateTime.Now;
            IsGrown = false;

            return (true, $"{Name} посажена ({SeedsPlanted} семян). Время роста: {GrowTime.TotalSeconds} сек.", seedsToPlant);
        }

        // Проверка роста
        public bool CheckGrowth()
        {
            if (!IsGrown && DateTime.Now - PlantedTime >= GrowTime)
            {
                IsGrown = true;
                return true;
            }
            return false;
        }

        // Сбор урожая
        public (bool success, int yield, string message) Harvest()
        {
            if (!IsGrown)
                return (false, 0, "Урожай ще не виріс.");

            int yield = TotalYield;
            IsGrown = false;
            SeedsPlanted = 0;
            PlantedTime = DateTime.MinValue;

            return (true, yield, $"{Name} зібрана: {yield} шт.");
        }
    }
}
