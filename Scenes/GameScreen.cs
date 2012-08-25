using DynaStudios.LD24.Game.Gui.Screens.Items;
using DynaStudios.LD24.Scenes.HUD;
﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using DynaStudios.UI.Input;

using DynaStudios.LD24.Game.Entities;
using DynaStudios.LD24.Game.NonEntities;

namespace DynaStudios.LD24.Scenes
{
    public class GameScreen : UI.Screens.GameScreen
    {
        public Camera Camera { get; set; }
        public Player Player;
        public InputState input;

        public GameScreen()
        {
            Player = new Player(this);
            Camera = new Camera(Player);
        }

        public override void Activate(bool instancePreserved)
        {
            ZIndex = -1;

            //Create HudScreen
            PlayerHUD playerHud = new PlayerHUD(Player) {ScreenPosition = ScreenPosition.Bottom, Size = new Vector2(600, 150)};
            ScreenManager.AddScreen(playerHud);

            base.Activate(instancePreserved);
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);
            Player.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Player.Draw(Camera, gameTime);
        }

        public override void HandleInput(GameTime gameTime, InputState input)
        {
            base.HandleInput(gameTime, input);
        }
    }
}
