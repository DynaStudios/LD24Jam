using Microsoft.Xna.Framework;

using DynaStudios.UI.Input;

using DynaStudios.LD24.Game.Entities;

namespace DynaStudios.LD24.Scenes
{
    public class GameScreen : UI.Screens.GameScreen
    {
        public Player Player;
        public InputState input;

        public GameScreen()
        {
            Player = new Player(this);
        }

        public override void Activate(bool instancePreserved)
        {
            base.Activate(instancePreserved);
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
            Player.Update(gameTime.TotalGameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void HandleInput(GameTime gameTime, InputState input)
        {
            base.HandleInput(gameTime, input);
        }
    }
}