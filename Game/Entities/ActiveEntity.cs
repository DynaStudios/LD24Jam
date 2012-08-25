using System;

namespace DynaStudios.LD24.Game.Entities
{
    public abstract class ActiveEntity : Entity
    {
        public abstract void Update(TimeSpan runTime);
    }
}
