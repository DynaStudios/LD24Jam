using DynaStudios.LD24.Game.Entities;
using DynaStudios.LD24.Game.Gui;
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

        private HealthBarInfo _healthBar;
        private ExperienceBar _dnaBar;
        private SpellBar _spellBar;
        private CharacterStatsInfo _characterStatsBase;

        public PlayerHUD(Player player)
        {
            _player = player;
            _player.BaseStats.MaxHealth = 100;
        }

        public override void Activate(bool instancePreserved)
        {
            //Add HealthBar and ProgressBar
            _healthBar = new HealthBarInfo {Position = new Vector2(20, 540)};
            _dnaBar = new ExperienceBar {Position = new Vector2(20, 650)};

            _spellBar = new SpellBar {Position = new Vector2(245, 655)};

            _characterStatsBase = new CharacterStatsInfo {Position = new Vector2(800, 550)};

            //Add Items to Panel
            PanelEntries.Add(_healthBar);
            PanelEntries.Add(_dnaBar);
            PanelEntries.Add(_spellBar);
            PanelEntries.Add(_characterStatsBase);

            base.Activate(instancePreserved);
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            _healthBar.Health = _player.BaseStats.Health;
            //todo: remove when Max Health implemented
            _player.BaseStats.MaxHealth = _player.BaseStats.MaxHealth;
            _healthBar.MaxHealth = _player.BaseStats.MaxHealth;
            //_healthBar.Power = _player.BaseStats.Power;
            _spellBar.Spells = _player.Equipment;

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }
    }
}