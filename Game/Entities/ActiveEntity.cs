using System;

using Microsoft.Xna.Framework;

using DynaStudios.UI.Input;

namespace DynaStudios.LD24.Game.Entities
{
    public abstract class ActiveEntity : Entity
    {
		protected float SpeedMeterPerSec = 10.0f;
		protected float TurningSpeedSec = 100.0f;

        public virtual void Update(GameTime gameTime, InputState inputState)
        {
            Position.UpdateVisual(gameTime.TotalGameTime);
        }
    }
}
