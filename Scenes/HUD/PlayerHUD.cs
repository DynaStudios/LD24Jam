using DynaStudios.LD24.Game.Entities;
using DynaStudios.LD24.Game.Gui.Components;
using DynaStudios.LD24.Game.Gui.Screens;
using DynaStudios.LD24.Game.Gui.Screens.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DynaStudios.LD24.Scenes.HUD
{
    public class PlayerHUD : HudScreen
    {
        private Player _player;

        private Bar _healthBar, _dnaProgressBar;

        public PlayerHUD(Player player)
        {
            _player = player;
        }

        public override void Activate(bool instancePreserved)
        {
            //Load HealthBar
            Texture2D healthBackground = ScreenManager.Game.Content.Load<Texture2D>("Images/UI/HUD/HealthBar");
            Texture2D dnaProgressBackground = ScreenManager.Game.Content.Load<Texture2D>("Images/UI/HUD/DNABar");

            //Add HealthBar and ProgressBar
            _healthBar = new Bar(healthBackground, _player.Health) { Size = new Vector2(100, 150), HudPosition = ScreenPosition.Left };
            _dnaProgressBar = new Bar(dnaProgressBackground, _player.Exp) { Size = new Vector2(100, 150), HudPosition = ScreenPosition.Right };

            //Add Items to Panel
            PanelEntries.Add(_healthBar);
            //TODO: Add Spellbar here
            PanelEntries.Add(_dnaProgressBar);

            base.Activate(instancePreserved);
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            _healthBar.Value = _player.Health;
            _dnaProgressBar.Value = _player.Exp;

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }
    }
}