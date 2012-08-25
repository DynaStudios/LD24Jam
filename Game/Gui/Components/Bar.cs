using DynaStudios.LD24.Game.Gui.Screens.Items;
using DynaStudios.UI.Components;
using DynaStudios.UI.Input;
using DynaStudios.UI.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace DynaStudios.LD24.Game.Gui.Components
{
    public class Bar : IGuiItem
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public int ZIndex { get; set; }
        public SoundEffect HoverSound { get; set; }
        public SoundEffect ClickSound { get; set; }

        public Texture2D Background { get; set; }
        public int Value { get; set; }
        public ScreenPosition HudPosition { get; set; }

        public Bar(Texture2D background, int value)
        {
            HudPosition = ScreenPosition.Left;

            Background = background;
            Value = value;
        }

        public float GetWidth(GameScreen gameScreen)
        {
            return Size.X;
        }

        public float GetHeight(GameScreen gameScreen)
        {
            return Size.Y;
        }

        public void Update(GameScreen gameScreen, GameTime gameTime)
        {
            //Nothing to do here
        }

        public void Draw(GameScreen gameScreen, GameTime gameTime)
        {
            var spriteBatch = gameScreen.ScreenManager.SpriteBatch;

            //Draw Background
            Rectangle backgroundRec = new Rectangle((int) Position.X, (int) Position.Y, (int) Size.X, (int) Size.Y);
            spriteBatch.Draw(Background, backgroundRec, Color.White);

            //Overlap not active part
            var newValue = 100 - Value;
            
            int overlapHeight = (int) (Size.Y/100*newValue);
            Rectangle usedRec = new Rectangle((int) Position.X, (int) Position.Y, (int) Size.X, overlapHeight);
            spriteBatch.Draw(gameScreen.ScreenManager.BlankTexture, usedRec, Color.DarkGray);

        }

        public void HandleInput(InputState input)
        {
            //Nothing to do here
        }

    }
}