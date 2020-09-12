using System;
using DistantEngine.Graphics;
using DistantEngine.Objects;
using DistantEngine.Objects.Components;
using Game.Objects;
using SDL2;
namespace Game
{
    internal class Program
    {
        public static void Main()
        {
            var win = new Window(800, 640, "Testing");
            var player = new Player("assets/player.png", 0, 0, 32, 32);
            var player2 = new Player2("assets/player.png", 128, 128, 32, 32);
            var player2Col = player2.GetComponent<ColliderComponent>();
            var player1Col = player.GetComponent<ColliderComponent>();
            var wall = new GameObject(0, 608, 3);
            wall.AddComponent<SpriteComponent>();
            wall.GetComponent<SpriteComponent>().Initialise("assets/water.png", 192, 192, 32, 800);
            wall.AddComponent<ColliderComponent>();
            var level1 =  new TextureMap();
            level1.DrawMap();
            while (win.Running)
            {
                if (player1Col.Collided(wall.GetComponent<ColliderComponent>()))
                {
                    player.IsGrounded = true;
                }
                win.FrameCheck();
                win.HandleEvents();
                win.Update();
                win.Render();
            }
            win.Clean();
        }
    }
}