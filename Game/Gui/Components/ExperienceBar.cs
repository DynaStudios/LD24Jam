using DynaStudios.UI.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DynaStudios.LD24.Game.Gui.Components
{
    public class ExperienceBar : SmallPanel
    {
        public Texture2D DnaInactiveTexture { get; set; }
        public Texture2D DnaTexture { get; set; }

        public int XP { get; set; }
        public int XPNeeded { get; set; }

        public override void Draw(GameScreen gameScreen, GameTime gameTime)
        {
            base.Draw(gameScreen, gameTime);

            if (DnaTexture == null)
            {
                DnaTexture = gameScreen.ScreenManager.Game.Content.Load<Texture2D>("Images/UI/HUD/DNA");
                DnaInactiveTexture = gameScreen.ScreenManager.Game.Content.Load<Texture2D>("Images/UI/HUD/GrayDNA");
            }

            var spriteBatch = gameScreen.ScreenManager.SpriteBatch;

            Rectangle grayDna = DnaInactiveTexture.Bounds;
            grayDna.X = (int) (Position.X + 25);
            grayDna.Y = (int) Position.Y + 20;
            spriteBatch.Draw(DnaInactiveTexture, grayDna, Color.White);

        }
    }
}