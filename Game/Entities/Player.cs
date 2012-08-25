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
        private Vector3 VisualPosition { get; set; }
        public Model Model { get; set; }
        public float ModelScaling { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Exp { get; set; }

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

        private void UpdateInput(GameTime gameTime) {
            var keyboardState = screen.input.KeyboardState;
            var position = Position.Real;

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

            Position.Real = position;
        }

        public override void Draw(Camera camera, GameTime gameTime)
        {
            Matrix[] modelTransforms = new Matrix[Model.Bones.Count];
            Model.CopyAbsoluteBoneTransformsTo(modelTransforms);
            Matrix playerModelScale = Matrix.CreateScale(ModelScaling);
            Matrix playerPositionScale = Matrix.CreateScale(1.0f / ModelScaling);
            Vector3 position3d = new Vector3(VisualPosition.X, 2.0f, VisualPosition.Y);
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
