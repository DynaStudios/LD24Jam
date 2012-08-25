using Microsoft.Xna.Framework;

using DynaStudios.LD24.Game;
using DynaStudios.LD24.Game.NonEntities;

namespace DynaStudios.LD24.Game.Entities {

    public abstract class Entity
    {
        public Position Position { get; set; }
        public Vector3 Direction { get; set; }
        public Vector3 Size { get; set; }

        public Entity ()
        {
            Position = new Position();
        }

        public abstract void Draw(Camera camera, GameTime gameTime);

        private bool Collide1D(float meStart, float meEnd, float entityStart, float entityEnd)
        {
            return meStart < entityEnd
                && meEnd > entityStart;
        }

        public bool Collides(Entity entity)
        {
            Vector3 StartMe = Position.Real - (Size / 2);
            Vector3 EndMe = Position.Real - (Size / 2);

            Vector3 StartEntity = entity.Position.Real - (entity.Size / 2);
            Vector3 EndEntity = entity.Position.Real - (entity.Size / 2);

            return Collide1D(StartMe.X, EndMe.X, StartEntity.X, EndEntity.X)
                && Collide1D(StartMe.Y, EndMe.Y, StartEntity.Y, EndEntity.Y)
                && Collide1D(StartMe.Z, EndMe.Z, StartEntity.Z, EndEntity.Z);
        }
    }
}
