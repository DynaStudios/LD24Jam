using System;

using Microsoft.Xna.Framework;

namespace DynaStudios.LD24.Game.Entities
{
    public abstract class ActiveEntity : Entity
    {
        public virtual void Update(GameTime gameTime)
        {
            Position.UpdateVisual(gameTime.TotalGameTime);
        }
    }
}
