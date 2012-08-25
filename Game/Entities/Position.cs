using System;

using Microsoft.Xna.Framework;

namespace DynaStudios.LD24.Game.Entities
{
    public class Position
    {
        private TimeSpan lastUpdate;
        private TimeSpan UpdateInterval;

        public Vector3 Real { get; set; }
        public float SteepSize { get; set; }
        public Vector3 Visual { get; set; }

        public Position()
        {
            // every 200ms (2000 x 100ns = 200ms)
            UpdateInterval = new TimeSpan(2000);
            SteepSize = 0.1f;
        }

        public void UpdateVisual(TimeSpan gameTime)
        {
            if (lastUpdate.Ticks == 0)
            {
                lastUpdate = gameTime;
                return;
            }

            TimeSpan timeDiff = gameTime - lastUpdate;
            while (timeDiff >= UpdateInterval)
            {
                Visual = Vector3.SmoothStep(Visual, Real, SteepSize);
                lastUpdate += UpdateInterval;
                timeDiff = gameTime - lastUpdate;
            }
        }
    }
}
