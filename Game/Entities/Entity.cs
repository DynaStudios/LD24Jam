using Microsoft.Xna.Framework;

using DynaStudios.LD24.Game;
using DynaStudios.LD24.Game.NonEntities;

namespace DynaStudios.LD24.Game.Entities {

    public abstract class Entity
    {
        public Position Position { get; set; }
        public Vector3 Direction { get; set; }

        public Entity ()
        {
            Position = new Position();
        }

        public abstract void Draw(Camera camera, GameTime gameTime);
    }
}
