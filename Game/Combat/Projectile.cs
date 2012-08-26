using Microsoft.Xna.Framework;

using DynaStudios.UI.Input;

using DynaStudios.LD24.Game.Entities;

namespace DynaStudios.LD24.Game.Combat
{
    public class Projectile : ActiveEntity
    {
        private Vector3 start;
        private float range;

        public Projectile(Vector3 start, Vector3 direction, float speed, float range)
        {
            this.start = start;
            this.range = range;
            Direction = direction;

            // Projectiles are to fast to make them move smothe and usual dont accelerate after lunching
            Position = new Position()
            {
                Real        = start,
                Visual      = start,
                SteepSize   = 1.0f
            };
        }

        public override void Update(GameTime gameTime, InputState inputState)
        {
            base.Update(gameTime, inputState);
        }

        public override void Draw(NonEntities.Camera camera, GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        public override void LoadResources(Microsoft.Xna.Framework.Content.ContentManager contentManager)
        {
            base.LoadResources(contentManager);
        }
    }
}
