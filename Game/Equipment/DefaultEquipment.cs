using DynaStudios.LD24.Game.Entities;
using Microsoft.Xna.Framework.Graphics;

namespace DynaStudios.LD24.Game.Equipment
{
    public class DefaultEquipment : IEquipment
    {
        public int Priority { get; set; }
        public Texture2D Icon { get; set; }

        public int Strenght { get; set; }
        public int Defence { get; set; }
        public int MaxHealth { get; set; }

        public DefaultEquipment()
        {
            Priority = 1000;

            Strenght = 1;
            Defence = 1;
            MaxHealth = 0;
        }

        public Stats getModfied(Stats stats)
        {
            return new Stats(stats)
            {
                Strenght = stats.Strenght + Strenght,
                Defence = stats.Defence + Defence,
                MaxHealth = MaxHealth + stats.MaxHealth
            };
        }
    }
}
