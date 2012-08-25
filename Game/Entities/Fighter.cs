using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.Xna.Framework.Graphics;

using DynaStudios.LD24.Game.Equipment;

namespace DynaStudios.LD24.Game.Entities
{
    public abstract class Fighter : ActiveEntity
    {
        public Stats BaseStats { get; protected set; }
        public Stats Stats { get; protected set; }
        public Weapen Weapen { get; protected set; }
        protected List<IEquipment> equipment = new List<IEquipment>();

        public ReadOnlyCollection<IEquipment> Equipment
        {
            get { return new ReadOnlyCollection<IEquipment>(equipment); }
        }

        public void SetWeapen(Weapen weapen)
        {
        }

        public void AddEqipment(IEquipment item)
        {
            equipment.Add(item);
            UpdateEquipment();
        }

        public void RemoveEqipment(IEquipment item)
        {
            equipment.Remove(item);
            UpdateEquipment();
        }

        protected void UpdateEquipment()
        {
            Stats = BaseStats;
            foreach (IEquipment item in equipment)
            {
                Stats = item.getModfied(Stats);
            }
        }
    }
}
