using DynaStudios.LD24.Game.Entities;

namespace DynaStudios.LD24.Game.Equipment
{
    public interface IEquipment
    {
        int Priority { get; }
        Stats getModfied(Stats stats);
    }
}
