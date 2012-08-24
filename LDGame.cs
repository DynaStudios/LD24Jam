using System;
using Microsoft.Xna.Framework;

namespace DynaStudios.LD24
{
    public class LDGame : Game
    {
        public GraphicsDeviceManager GraphicsDeviceManager { get; set; }

        public LDGame()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);

            //Set Content Folder
            Content.RootDirectory = "Content";

            //Enable VSync to save computer performance
            IsFixedTimeStep = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            base.Draw(gameTime);
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            base.OnExiting(sender, args);
        }
    }
}