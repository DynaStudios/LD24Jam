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
        
        protected List<Weapon> weapons { get; set; }
        protected ReadOnlyCollection<Weapon> Weapons { get; set; }
        protected List<IEquipment> equipment = new List<IEquipment>();


        public void HitTarget(Weapon weapon, Fighter target)
        {
            target.TakeDemage(weapon.GetAttackForce(Stats));
        }

        public void TakeDemage(int deamage)
        {
            Stats.Health -= deamage / Stats.Defence - Stats.Defence;
            if (Stats.Health <= 0 && Died != null)
            {
                Died(this);
            }
        }

        public void AddWeapon(Weapon weapon)
        {
            weapons.Add(weapon);
            AddEqipment(weapon);
        }

        public void RemoveWeapon(Weapon weapon)
        {
            weapons.Remove(weapon);
            RemoveEqipment(weapon);
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
            Weapons = new ReadOnlyCollection<Weapon>(weapons);
        }
    }
}
