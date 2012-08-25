using System;
using DynaStudios.LD24.Scenes;
using DynaStudios.UI;
using Microsoft.Xna.Framework;

namespace DynaStudios.LD24
{
    public class LDGame : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager GraphicsDeviceManager { get; set; }

        private readonly ScreenFactory _screenFactory;
        private readonly ScreenManager _screenManager;

        public LDGame()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);

            //Set Content Folder
            Content.RootDirectory = "Content";

            //Enable VSync to save computer performance
            IsFixedTimeStep = true;

            //GUI and Game Screen Managment Init
            _screenFactory = new ScreenFactory();
            Services.AddService(typeof(IScreenFactory), _screenFactory);

            _screenManager = new ScreenManager(this);
            Components.Add(_screenManager);
            AddInitialScreens();

        }

        private void AddInitialScreens()
        {
            _screenManager.AddScreen(new MainMenu());    
        }

        protected override void Initialize()
        {
            GraphicsDeviceManager.PreferredBackBufferWidth = 1024;
            GraphicsDeviceManager.PreferredBackBufferHeight = 768;

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