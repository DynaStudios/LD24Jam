using System.Collections.Generic;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using DynaStudios.UI.Input;

using DynaStudios.LD24.Game.Gui.Screens.Items;
using DynaStudios.LD24.Scenes.HUD;
using DynaStudios.LD24.Game;
using DynaStudios.LD24.Game.Entities;
using DynaStudios.LD24.Game.NonEntities;

namespace DynaStudios.LD24.Scenes
{
    public class GameScreen : UI.Screens.GameScreen
    {
        private Matrix worldMatrix;
        public Map Map;
        public Camera Camera { get; set; }

        public Player Player;

        public GameScreen()
        {
        }

        public override void Activate(bool instancePreserved)
        {
            worldMatrix = Matrix.Identity;
            ZIndex = -1;

            Map = new Map();
            Map.Load(Path.Combine("Content", "Map.xml"));

            Player = new Player(this);
            Camera = new Camera(Player);
            Map.SmartAdd(Player);

            //Create HudScreen
            PlayerHUD playerHud = new PlayerHUD(Player) {
                ScreenPosition = ScreenPosition.Bottom,
                Size = new Vector2(600, 150)
            };
            ScreenManager.AddScreen(playerHud);

            base.Activate(instancePreserved);
            LoadResources();
        }

        private void LoadResources()
        {
            Map.ForEachEntity((entity) =>
            {
                entity.LoadResources(ScreenManager.Game.Content);
            });
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Map.ForEachEntity((entity) =>
            {
                entity.Draw(Camera, gameTime);
            });
        }

        public override void HandleInput(GameTime gameTime, InputState input)
        {
            base.HandleInput(gameTime, input);
            UpdateCamera(input);
            Map.ForEachActiveEntity((entity) =>
            {
                entity.Update(gameTime, input);
            });
        }

        private void UpdateCamera(InputState input)
        {
            var keyBoardState = input.KeyboardState;
            //Rotate Cube along its Up Vector
            if (keyBoardState.IsKeyDown(Keys.X))
            {
                worldMatrix = Matrix.CreateFromAxisAngle(Vector3.Up, .02f) * worldMatrix;
            }
            if (keyBoardState.IsKeyDown(Keys.Z))
            {
                worldMatrix = Matrix.CreateFromAxisAngle(Vector3.Up, -.02f) * worldMatrix;
            }

            //Move Cube Forward, Back, Left, and Right
            if (keyBoardState.IsKeyDown(Keys.Up))
            {
                worldMatrix *= Matrix.CreateTranslation(worldMatrix.Forward);
            }
            if (keyBoardState.IsKeyDown(Keys.Down))
            {
                worldMatrix *= Matrix.CreateTranslation(worldMatrix.Backward);
            }
            if (keyBoardState.IsKeyDown(Keys.Left))
            {
                worldMatrix *= Matrix.CreateTranslation(-worldMatrix.Right);
            }
            if (keyBoardState.IsKeyDown(Keys.Right))
            {
                worldMatrix *= Matrix.CreateTranslation(worldMatrix.Right);
            }

            Camera.Update(worldMatrix);
        }
    }
}
