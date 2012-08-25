using DynaStudios.LD24.Game.Entities;

namespace DynaStudios.LD24.Game.Equipment
{
    public class Weapen : IEquipment
    {
        public int Priority { get; set; }

        public int Power { get; set; }

        public Weapen()
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
