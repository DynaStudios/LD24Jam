using DynaStudios.LD24.Game.Gui.Screens.Items;
using DynaStudios.LD24.Scenes.HUD;
﻿using Microsoft.Xna.Framework;
﻿using System.Collections.Generic;
using System.IO;

using Microsoft.Xna.Framework.Graphics;

using DynaStudios.UI.Input;

using DynaStudios.LD24.Game;
using DynaStudios.LD24.Game.Entities;
using DynaStudios.LD24.Game.NonEntities;

namespace DynaStudios.LD24.Scenes
{
    public class GameScreen : UI.Screens.GameScreen
    {
        public Map Map;
        public Camera Camera { get; set; }

        public Player Player;

        public GameScreen()
        {
            
        }

        public override void Activate(bool instancePreserved)
        {
            ZIndex = -1;

            Map = new Map();
            Map.Load(Path.Combine("Content", "Map.xml"));

            Player = new Player(this);
            Camera = new Camera(Player);
            Map.SmartAdd(Player);

            //Create HudScreen
            PlayerHUD playerHud = new PlayerHUD(Player) {ScreenPosition = ScreenPosition.Bottom, Size = new Vector2(600, 150)};
            ScreenManager.AddScreen(playerHud);

            base.Activate(instancePreserved);
            Map.LoadResources(ScreenManager.Game.Content);
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Map.Draw(Camera, gameTime);
        }

        public override void HandleInput(GameTime gameTime, InputState input)
        {
            base.HandleInput(gameTime, input);
            Map.Update(gameTime, input);
        }
    }
}
