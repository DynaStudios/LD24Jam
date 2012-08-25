using DynaStudios.LD24.Game.Entities;

namespace DynaStudios.LD24.Game.Equipment
{
    public class DefaultEquipment : IEquipment
    {
        public int Priority { get; set; }

        // multiplicated values
        public int Strenght { get; set; }

        // added values
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
            return new Stats
            {
                Strenght = stats.Strenght * Strenght,
                Defence = stats.Defence + Defence,
                MaxHealth = MaxHealth + stats.MaxHealth
            };
        }
    }
}
