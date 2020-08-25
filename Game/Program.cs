using System;
using DistantLands.Graphics;
using DistantLands.Objects;

namespace Game
{
    class Program
    {
        public static void Main()
        {
            Window win = new Window(800, 640, false, "Testing");
            Player player = new Player("assets/player.png", 0, 0, 32, 32);
            while (win.Running)
            {
                win.FrameCheck();
                win.HandleEvents();
                win.Update();
                win.Render();
            }
            win.Clean();
        }
    }
}