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

        public HudScreen()
        {
            PanelEntries = new List<IGuiItem>();
        }

        public override void Activate(bool instancePreserved)
        {
            base.Activate(instancePreserved);
        }

        public override void Draw(GameTime gameTime)
        {

            var spriteBatch = ScreenManager.SpriteBatch;
            spriteBatch.Begin();

            foreach (var panelEntry in PanelEntries)
            {
                panelEntry.Draw(this, gameTime);
            }

            spriteBatch.End();
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