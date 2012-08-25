﻿using System.Collections.Generic;
using DynaStudios.LD24.Game.Gui.Screens.Items;
using DynaStudios.UI.Components;
using DynaStudios.UI.Input;
using DynaStudios.UI.Screens;
using Microsoft.Xna.Framework;

namespace DynaStudios.LD24.Game.Gui.Screens
{
    public class HudScreen : GameScreen
    {
        public List<IGuiItem> PanelEntries { get; set; }
        public Vector2 PresentationOffset { get; set; }
        public Vector2 Size { get; set; }

        public ScreenPosition ScreenPosition { get; set; }

        public HudScreen()
        {
            //Set Default Screen Position
            ScreenPosition = ScreenPosition.Bottom;

            PanelEntries = new List<IGuiItem>();
            PresentationOffset = new Vector2(0,0);
            Size = new Vector2(200, 200);
        }

        public override void Activate(bool instancePreserved)
        {
            var viewport = ScreenManager.GraphicsDevice.Viewport;

            switch (ScreenPosition)
            {
                case ScreenPosition.Top:
                    var startTopX = viewport.Width/2 - Size.X / 2;
                    PresentationOffset = new Vector2(startTopX, 0);
                    break;
                    
                case ScreenPosition.Left:
                    var startLeftY = viewport.Height/2 - Size.Y/2;
                    PresentationOffset = new Vector2(0, startLeftY);
                    break;
                
                case ScreenPosition.Right:
                    var startRightX = viewport.Width - Size.X;
                    var startRightY = viewport.Height/2 - Size.Y/2;
                    PresentationOffset = new Vector2(startRightX, startRightY);
                    break;
                
                case ScreenPosition.Bottom:
                    var startBottomX = viewport.Width/2 - Size.X/2;
                    var startBottomY = viewport.Height - Size.Y;
                    PresentationOffset = new Vector2(startBottomX, startBottomY);
                    break;
            }

            base.Activate(instancePreserved);
        }

        public override void Draw(GameTime gameTime)
        {
            CalculateItemPositions();

            var spriteBatch = ScreenManager.SpriteBatch;
            spriteBatch.Begin();

            Rectangle testRec = new Rectangle((int) PresentationOffset.X, (int) PresentationOffset.Y, (int) Size.X, (int) Size.Y);
            spriteBatch.Draw(ScreenManager.BlankTexture, testRec, Color.Black);

            foreach (var panelEntry in PanelEntries)
            {
                panelEntry.Draw(this, gameTime);
            }

            spriteBatch.End();
        }

        private void CalculateItemPositions()
        {
            var position = PresentationOffset;
            

        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void HandleInput(GameTime gameTime, InputState input)
        {
            base.HandleInput(gameTime, input);
        }
    }
}