using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.Xna.Framework.Graphics;

using DynaStudios.LD24.Game.Equipment;

namespace DynaStudios.LD24.Game.Entities
{
    public delegate void PassingFighterDelegate(Fighter fighter);

    public abstract class Fighter : ActiveEntity
    {
        public event PassingFighterDelegate Died;
        public Stats BaseStats { get; protected set; }
        public Stats Stats { get; protected set; }
        public ReadOnlyCollection<IEquipment> Equipment { get; private set; }
        
        protected List<Weapen> weapens { get; set; }
        protected ReadOnlyCollection<Weapen> Weapens { get; set; }
        protected List<IEquipment> equipment = new List<IEquipment>();


        public void HitTarget(Weapen weapen, Fighter target)
        {
            target.TakeDemage(weapen.GetAttackForce(Stats));
        }

        public void TakeDemage(int deamage)
        {
            Stats.Health -= deamage / Stats.Defence - Stats.Defence;
            if (Stats.Health <= 0 && Died != null)
            {
                Died(this);
            }
        }

        public void AddWeapen(Weapen weapen)
        {
            weapens.Add(weapen);
            AddEqipment(weapen);
        }

        public void RemoveWeapen(Weapen weapen)
        {
            weapens.Remove(weapen);
            RemoveEqipment(weapen);
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
            Equipment = new ReadOnlyCollection<IEquipment>(equipment);
            Weapens = new ReadOnlyCollection<Weapen>(weapens);
        }
    }
}
