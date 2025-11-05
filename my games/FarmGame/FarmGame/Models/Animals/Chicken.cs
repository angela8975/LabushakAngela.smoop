using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmGame.Models
{
    public class Chicken : Animals
    {
        public Chicken(Coop coop)
            :base("Chicken","Chiecken feed", TimeSpan.FromMinutes(5), 3, "Egg", 1, 100, coop)
        {

        }
    }
}
