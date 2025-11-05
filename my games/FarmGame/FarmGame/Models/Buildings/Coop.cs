using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmGame.Models
{
    public class Coop : Building
    {
        public List<Chicken> Chickens { get; private set; } = new List<Chicken>();

        public Coop()
            :base("Chicken Coop", 1,150,50,6,TimeSpan.FromMinutes(3),false)
        {

        }
        public bool AddChicken(Chicken chicken)
        {
            if (Chickens.Count >= Capacity)
                return false;

            Chickens.Add(chicken);
            chicken.BuildingHome = this; // прив’язуємо курку до курятника
            return true;
        }
    }
}
