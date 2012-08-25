using DynaStudios.LD24.Game.Gui.Screens.Items;
using DynaStudios.LD24.Scenes.HUD;
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
            ZIndex = -1;

            //Create HudScreen
            PlayerHUD playerHud = new PlayerHUD(Player) {ScreenPosition = ScreenPosition.Bottom, Size = new Vector2(500, 150)};
            ScreenManager.AddScreen(playerHud);

            base.Activate(instancePreserved);
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);
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