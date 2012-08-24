using System;

namespace DynaStudios.LD24
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LDGame game = new LDGame();
            game.Run();
        }
    }
}
