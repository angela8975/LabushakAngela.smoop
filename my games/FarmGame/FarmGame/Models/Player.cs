using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmGame.Models
{
    public class Player
    {
        public int Level { get; private set; }
        public int Exp { get; private set; }
        public int ExpForNextLevel { get; private set; } = 50;
        
        
        public int Coins { get; set; }
        public int Crystals { get; set; }

        public List<Building> Buildings { get; set; } = new List<Building>();

        public Player() 
        {
            Level = 1;
            Exp = 0;
            Coins = 0;
            Crystals = 0;
        }
        public void AddExp(int amount)
        {
            Exp += amount; // можно добавить сообщение сколько получено хп
            while (Exp >= ExpForNextLevel)
            {
                LevelUp();
            }
        }
        public void LevelUp()
        {
            Exp -= ExpForNextLevel;
            Level++;  // можно добавить сообщение сколько получено хп
            ApplyLevelRewards(Level);
            UpdateXPRequirement();
        }
        private void ApplyLevelRewards(int newLevel)
        {
            switch (newLevel)
            {
                
                case 1:
                    int rewardCoins1 = 300;
                    int rewardCrystals1 = 5;

                    Field newField = new Field("Smoll field 1", 50, 25, 5);
                    Barn newBarn = new Barn("Barn", 50, 25);
                    Crop newCrop = new Crop("wheat", TimeSpan.FromMinutes(1), 1, 3);


                    Coins += rewardCoins1;
                    Crystals += rewardCrystals1;
                    break;
                    
                case 2:
                    Crop newCrop2 = new Crop("corn", TimeSpan.FromMinutes(3), 2, 3);
                    //Coop newCoop = new Coop();
                    //FiedMeal newFiedMeal = new FiedMeal();
                    //Animals newAnimal = new Animals("chicken");
                    

                    Coins += 300;
                    Crystals += 5;
                    break;
                    case 3:
                    // Shop newShop = new Shop();

                    break;
            }
        }
        private void UpdateXPRequirement()
        {
            ExpForNextLevel = Level * 50;
        }

    }
}

