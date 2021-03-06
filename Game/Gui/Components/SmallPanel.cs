﻿using DynaStudios.UI.Components;
using DynaStudios.UI.Input;
using DynaStudios.UI.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace DynaStudios.LD24.Game.Gui.Components
{
    public class SmallPanel : IGuiItem
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public int ZIndex { get; set; }
        public SoundEffect HoverSound { get; set; }
        public SoundEffect ClickSound { get; set; }

        public Texture2D PanelBackground { get; set; }

        public SmallPanel()
        {
            Size = new Vector2(213, 108);
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
        }

        public virtual void Draw(GameScreen gameScreen, GameTime gameTime)
        {
            var spriteBatch = gameScreen.ScreenManager.SpriteBatch;

            if (PanelBackground == null)
            {
                PanelBackground = gameScreen.ScreenManager.Game.Content.Load<Texture2D>("Images/UI/smallPanel");
            }

            Rectangle panelBg = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            spriteBatch.Draw(PanelBackground, panelBg, Color.White);

        }

        public void HandleInput(InputState input)
        {
        }

    }
}