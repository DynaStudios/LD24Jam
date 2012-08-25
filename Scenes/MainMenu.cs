using System;
using DynaStudios.UI.Components;
using DynaStudios.UI.Screens;
using Microsoft.Xna.Framework;

namespace DynaStudios.LD24.Scenes
{
    public class MainMenu : MenuScreen 
    {

        public override void Activate(bool instancePreserved)
        {
            var viewport = ScreenManager.GraphicsDevice.Viewport;
            PresentationOffset = new Vector2(viewport.Width / 2, viewport.Height / 2);

            Button startGameButton = new Button("Start Game") { FillColor = Color.Blue, HoverColor = Color.Orange };
            Button aboutButton = new Button("About") { FillColor = Color.Blue, HoverColor = Color.Orange };

            startGameButton.Clicked += StartGameButtonClicked;
            aboutButton.Clicked += AboutButtonClicked;

            MenuEntries.Add(startGameButton);
            MenuEntries.Add(aboutButton);

            base.Activate(instancePreserved);
        }

        private void StartGameButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Start Game Button Clicked");
        }


        private void AboutButtonClicked(object sender, EventArgs e)
        {

        }
    }
}