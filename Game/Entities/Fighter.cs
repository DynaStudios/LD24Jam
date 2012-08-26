using System;
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
        public bool IsAlive { get { return Stats.Health > 0; } }
        public ReadOnlyCollection<IEquipment> Equipment { get; private set; }
        public ReadOnlyCollection<Weapon> Weapons { get; private set; }
        
        protected List<Weapon> weapons { get; set; }
        protected List<IEquipment> equipment = new List<IEquipment>();

        public Fighter()
        {
            BaseStats = new Stats
            {
                Strenght = 10,
                Defence = 5,
                MaxHealth = 100,
                Health = 100,
                Exp = 0
            };
            equipment = new List<IEquipment>();
            weapons = new List<Weapon>();

            UpdateEquipment();
        }

        public void HitTarget(Weapon weapon, Fighter target)
        {
            target.TakeDemage(weapon.GetAttackForce(Stats));
        }

        public void TakeDemage(int deamage)
        {
            Stats.Health -= Math.Max(deamage / Stats.Defence - Stats.Defence, 0);
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
            const int HealthCalcPrcision = 10000;
            int healthPart = Stats.Health * HealthCalcPrcision / Stats.MaxHealth;
            Stats = BaseStats;
            foreach (IEquipment item in equipment)
            {
                Stats = item.getModfied(Stats);
            }
            Equipment = new ReadOnlyCollection<IEquipment>(equipment);
            Weapons = new ReadOnlyCollection<Weapon>(weapons);
            Stats.Health = Stats.MaxHealth * healthPart / HealthCalcPrcision;
        }
    }
}
