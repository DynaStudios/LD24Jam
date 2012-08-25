using DynaStudios.UI.Components;
using DynaStudios.UI.Input;
using DynaStudios.UI.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DynaStudios.LD24.Game.Gui.Components
{
    public class SpellButton : IconButton
    {
        public bool IsSelected { get; set; }

        public SpellButton(Texture2D icon, string buttonText = "") : base(icon, buttonText)
        {
        }

        public SpellButton(Texture2D icon, Texture2D backgroundTexture, string buttonText = "") : base(icon, backgroundTexture, buttonText)
        {
        }

        public override void Draw(GameScreen gameScreen, GameTime gameTime)
        {
            var spriteBatch = gameScreen.ScreenManager.SpriteBatch;

            //Draw Spell here
            Rectangle rec = new Rectangle(0,0,0,0);
            spriteBatch.Draw(Icon, rec, Color.White);

            if (IsSelected)
            {
                //Draw Border here
            }

        }

        public override void HandleInput(InputState input)
        {
            base.HandleInput(input);
        }
    }
}