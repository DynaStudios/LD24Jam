using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using DynaStudios.LD24.Scenes;

namespace DynaStudios.LD24.Game.Entities
{
    public class Player : ActiveEntity
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Exp { get; set; }

        private GameScreen screen;

        public Player(GameScreen screen)
        {
            this.screen = screen;
        }

        public override void Update(TimeSpan runTime)
        {
            if (screen == null || screen.input == null || screen.input.KeyboardState == null)
            {
                return;
            }

            var keyboardState = screen.input.KeyboardState;
            var position = Position;

            if (keyboardState.IsKeyDown(Keys.W))
            {
                position.Z += 1.0f;
            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                position.Z -= 1.0f;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                position.X -= 1.0f;
            }
            else
            {
                position.X += 1.0f;
            }
        }
    }
}
