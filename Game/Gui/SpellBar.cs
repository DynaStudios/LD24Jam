using System.Collections.Generic;
using System.Collections.ObjectModel;
using DynaStudios.LD24.Game.Equipment;
using DynaStudios.LD24.Game.Gui.Components;
using DynaStudios.UI.Components;
using DynaStudios.UI.Input;
using DynaStudios.UI.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace DynaStudios.LD24.Game.Gui
{
    public class SpellBar : BigPanel
    {
        public ReadOnlyCollection<IEquipment> Spells { get; set; }
        public int SelectedIndex { get; set; }

        public override void Draw(GameScreen gameScreen, GameTime gameTime)
        {
            base.Draw(gameScreen, gameTime);

            var spriteBatch = gameScreen.ScreenManager.SpriteBatch;

        }
    }
}