using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmGame.Models
{
    public abstract class Building
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int BuildCost {  get; set; }
        public int ExpReward {  get; set; }
        public int Capacity { get; set; }
        public TimeSpan BuildTime { get; set; }
        public DateTime BuildStartTime { get; private set; }
        public bool IsBuilt { get; set; }
        
        public Building(string name, int level, int buildCost, int expReward, int capacity, TimeSpan buildTime, bool isBuilt)
        {
            Name = name;
            Level = level;
            BuildCost = buildCost;
            ExpReward = expReward;
            Capacity = capacity;
            BuildTime = buildTime;
            IsBuilt = isBuilt;
        }
        public void StartBuilding()
        {
            BuildStartTime = DateTime.Now;
            IsBuilt = false;
        }
        public virtual void Build (Player player)
        {
            if (player.Coins>= BuildCost)
            {
                player.Coins -= BuildCost;
                player.AddExp(ExpReward);
                IsBuilt = true;
            }
            else
            {
                Console.WriteLine("Not enogh money");
            }
        }
    }
}
