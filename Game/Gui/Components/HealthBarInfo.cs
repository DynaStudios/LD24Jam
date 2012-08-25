using DynaStudios.UI.Components;
using DynaStudios.UI.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DynaStudios.LD24.Game.Gui.Components
{
    public class HealthBarInfo : SmallPanel
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Power { get; set; }

        public Texture2D BarsTexture { get; set; }
        public Texture2D BarsInactiveTexture { get; set; }

        public override void Draw(GameScreen gameScreen, GameTime gameTime)
        {
            base.Draw(gameScreen, gameTime);

            if (BarsTexture == null)
            {
                BarsTexture = gameScreen.ScreenManager.Game.Content.Load<Texture2D>("Images/UI/HUD/bars_colored");
                BarsInactiveTexture = gameScreen.ScreenManager.Game.Content.Load<Texture2D>("Images/UI/HUD/bars_grayed");
            }

            var healthTextPosition = new Vector2(Position.X + 20, Position.Y + 20);
            var powerTextPosition = new Vector2(Position.X + 20, Position.Y + 60);

            var spriteBatch = gameScreen.ScreenManager.SpriteBatch;
            
            spriteBatch.DrawString(gameScreen.ScreenManager.Font, "Health", healthTextPosition, Color.White);
            spriteBatch.DrawString(gameScreen.ScreenManager.Font, "Power", powerTextPosition, Color.White);

            //Draw Healthbar and Powerbar
            //First draw grayed
            Rectangle grayedHealthRec = BarsInactiveTexture.Bounds;
            grayedHealthRec.X = (int) Position.X + 100;
            grayedHealthRec.Y = (int) Position.Y + 20;
            spriteBatch.Draw(BarsInactiveTexture, grayedHealthRec, Color.White);
            grayedHealthRec.Y += 40;
            spriteBatch.Draw(BarsInactiveTexture, grayedHealthRec, Color.White);


            if (MaxHealth != 0) { 
                //Draw Health Bar
                Rectangle healthRec = BarsTexture.Bounds;

                Rectangle visibleCrop = healthRec;
                visibleCrop.Width = (Health / MaxHealth) * healthRec.Width;

                spriteBatch.Draw(BarsTexture, new Vector2(Position.X + 100, Position.Y + 20), visibleCrop, Color.Red);
            }



        }
    }
}