using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using DynaStudios.LD24.Scenes;
using DynaStudios.LD24.Game.NonEntities;

namespace DynaStudios.LD24.Game.Entities
{
    public class Player : ActiveEntity
    {
        public Model Model { get; set; }
        public float ModelScaling { get; set; }

        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Exp { get; set; }
        public int Strenght { get; set; }
        public int Defence { get; set; }

        private GameScreen screen;

        public Player(GameScreen screen)
        {
            this.screen = screen;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (screen == null || screen.input == null || screen.input.KeyboardState == null)
            {
                return;
            }

            UpdateInput(gameTime);
        }

		// for better overview define...
		private float sin (double ang) { return (float) Math.Sin (ang/180.0*Math.PI); }
		private float cos (double ang) { return (float) Math.Cos (ang/180.0*Math.PI); }
		private float sqrt2 = (float) Math.Sqrt(2.0) * 0.5f;

        private void UpdateInput (GameTime gameTime)
		{
			var keyboardState = screen.input.KeyboardState;
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
            Matrix[] modelTransforms = new Matrix[Model.Bones.Count];
            Model.CopyAbsoluteBoneTransformsTo(modelTransforms);
            Matrix playerModelScale = Matrix.CreateScale(ModelScaling);
            Matrix playerPositionScale = Matrix.CreateScale(1.0f / ModelScaling);
            Vector3 position3d = new Vector3(Position.Visual.X, 2.0f, Position.Visual.Y);
            Matrix position3dMatrix = Matrix.CreateTranslation(position3d);

            foreach (ModelMesh mesh in Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
                    effect.World = (modelTransforms[mesh.ParentBone.Index] * playerModelScale) * position3dMatrix;
                    effect.View = camera.ViewMatrix;
                    effect.Projection = camera.ProjectionMatrix;
                }
                mesh.Draw();
            }
        }
    }
}
