using DynaStudios.LD24.Game.Entities;
using DynaStudios.LD24.Game.Gui.Screens;

namespace DynaStudios.LD24.Scenes.HUD
{
    public class PlayerHUD : HudScreen
    {
        private Player _player;

        public PlayerHUD(Player player)
        {
            _player = player;
        }
    }
}