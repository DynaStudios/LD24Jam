using DynaStudios.LD24.Game.Entities;
using Microsoft.Xna.Framework.Graphics;

namespace DynaStudios.LD24.Game.Equipment
{
    public interface IEquipment
    {
        int Priority { get; }
        Texture2D Icon { get; set; }
        Stats getModfied(Stats stats);
    }
}
