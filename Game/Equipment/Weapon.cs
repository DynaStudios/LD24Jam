﻿using DynaStudios.LD24.Game.Entities;
using Microsoft.Xna.Framework.Graphics;

namespace DynaStudios.LD24.Game.Equipment
{
    public class Weapon : IEquipment
    {
        public int Priority { get; set; }
        public Texture2D Icon { get; set; }

        public int Power { get; set; }

        public Weapon()
        {
            Priority = 2000;
            Power = 10;
        }

        public int GetAttackForce(Stats stats)
        {
            return stats.Strenght * Power;
        }

        public Stats getModfied(Stats stats)
        {
            return stats;
        }
    }
}
