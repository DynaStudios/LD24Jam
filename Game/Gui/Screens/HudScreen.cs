using System.Collections.Generic;
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

        public HudScreen()
        {
            PanelEntries = new List<IGuiItem>();
            PresentationOffset = new Vector2(0,0);
        }

        public override void Activate(bool instancePreserved)
        {
            base.Activate(instancePreserved);
        }

        public override void Draw(GameTime gameTime)
        {
            CalculateItemPositions();

            var spriteBatch = ScreenManager.SpriteBatch;
            spriteBatch.Begin();

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