using System.Collections.Generic;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using DynaStudios.UI.Input;

using DynaStudios.LD24.Game;
using DynaStudios.LD24.Game.Entities;
using DynaStudios.LD24.Game.NonEntities;

namespace DynaStudios.LD24.Scenes
{
    public class GameScreen : UI.Screens.GameScreen
    {
        public Map Map;
        public Camera Camera { get; set; }

        public InputState input;

        public GameScreen()
        {
            Map = new Map();
            Map.Load(Path.Combine("Content", "Map.xml"));
            Player player = new Player(this);

            Camera = new Camera(player);
            Map.SmartAdd(player);
        }

        public override void Activate(bool instancePreserved)
        {
            base.Activate(instancePreserved);
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
            Map.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Map.Draw(Camera, gameTime);
        }

        public override void HandleInput(GameTime gameTime, InputState input)
        {
            base.HandleInput(gameTime, input);
        }
    }
}
