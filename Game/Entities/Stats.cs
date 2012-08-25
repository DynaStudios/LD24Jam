using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynaStudios.LD24.Game.Entities
{
    public class Stats
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Strenght { get; set; }
        public int Defence { get; set; }
        public int Exp { get; set; }

        public Stats()
        {
        }

        public Stats(Stats stats)
        {
            Health = stats.Health;
            MaxHealth = stats.MaxHealth;
            Strenght = stats.Strenght;
            Defence = stats.Defence;
            Exp = stats.Exp;
        }
    }
}
