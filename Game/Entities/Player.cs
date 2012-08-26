using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using DynaStudios.UI.Input;

using DynaStudios.LD24.Scenes;
using DynaStudios.LD24.Game.NonEntities;
using DynaStudios.LD24.Game.Equipment;

namespace DynaStudios.LD24.Game.Entities
{
    public class Player : Fighter
    {

        private GameScreen screen;

        public Player(GameScreen screen)
        {
            this.screen = screen;
            BaseStats = new Stats
            {
                Strenght = 10,
                Defence = 10,
                MaxHealth = 100,
                Health = 100,
                Exp = 0
            };

            //Test here
            AddSampleSpells();

            UpdateEquipment();
        }

        private void AddSampleSpells()
        {
            Weapon testSpell1 = new Weapon();
            Weapon testSpell2 = new Weapon();

            var spellIconTest = screen.ScreenManager.Game.Content.Load<Texture2D>("Images/Spells/Fireball");

            testSpell1.Priority = 1;
            testSpell2.Priority = 1;

            testSpell1.Icon = spellIconTest;
            testSpell2.Icon = spellIconTest;

            testSpell1.Power = 20;
            testSpell2.Power = 20;
            
            AddEqipment(testSpell1);
            AddEqipment(testSpell2);
        }

        public override void Update(GameTime gameTime, InputState inputState)
        {
            base.Update(gameTime, inputState);

            if (inputState == null || inputState.KeyboardState == null)
            {
                return;
            }

            UpdateInput(gameTime, inputState);
        }

		// for better overview define...
		private float sin (double ang) { return (float) Math.Sin (ang/180.0*Math.PI); }
		private float cos (double ang) { return (float) Math.Cos (ang/180.0*Math.PI); }
		private float sqrt2 = (float) Math.Sqrt(2.0) * 0.5f;

        private void UpdateInput(GameTime gameTime, InputState inputState)
		{
			var keyboardState = inputState.KeyboardState;
			var position = Position.Real;
			var direction = Direction;
			float distance= moving_speed_s / 60.0f; // the distance this object can move during this update
			float angle   = turning_speed_s / 60.0f; // the angle by which this object can turn during this update

			if (keyboardState.IsKeyDown (Keys.Up)) {
				direction.X -= angle;
			}
			if (keyboardState.IsKeyDown (Keys.Down)) {
				direction.X += angle;
			}
			if (keyboardState.IsKeyDown (Keys.Left)) {
				direction.Y -= angle;
			}
			if (keyboardState.IsKeyDown (Keys.Right)) {
				direction.Y += angle;
			}
			Direction=direction;

			//again, for easier understanding of the code...
			bool keyLeft =  keyboardState.IsKeyDown (Keys.A);
			bool keyRight = keyboardState.IsKeyDown (Keys.D);
			bool keyFore =  keyboardState.IsKeyDown (Keys.W);
			bool keyBack =  keyboardState.IsKeyDown (Keys.S);

			if (keyLeft) {
				//            use triangular functions
				//            so we move around the floor
				//            according to "Direction"
				//                                            multiplying by "sqrt2" asserts that
				//                                            this object can not move faster than
				//                                            "distance" by using two non-linear
				//                                            directions (e.g. forewards and
				//                                            sidewards) at the same time
				position.X -= cos (Direction.Y) * distance * (keyFore || keyBack ? sqrt2 : 1.0f);
				position.Z -= sin (Direction.Y) * distance * (keyFore || keyBack ? sqrt2 : 1.0f);
			}
			if (keyRight) {
				position.X += cos (Direction.Y) * distance * (keyFore || keyBack ? sqrt2 : 1.0f);
				position.Z += sin (Direction.Y) * distance * (keyFore || keyBack ? sqrt2 : 1.0f);
			}
			if (keyFore) {
				position.Z -= cos (Direction.Y) * distance * (keyFore || keyBack ? sqrt2 : 1.0f);
				position.X += sin (Direction.Y) * distance * (keyFore || keyBack ? sqrt2 : 1.0f);
			}
			if (keyBack) {
				position.Z -= cos (Direction.Y) * distance * (keyFore || keyBack ? sqrt2 : 1.0f);
				position.X += sin (Direction.Y) * distance * (keyFore || keyBack ? sqrt2 : 1.0f);
			}
            Position.Real = position;
        }

        public override void Draw(Camera camera, GameTime gameTime)
        {
        }

        public override void LoadResources(Microsoft.Xna.Framework.Content.ContentManager contentManager)
        {
        }
    }
}
