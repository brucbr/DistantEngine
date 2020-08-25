#region Using Statements
using System;
using System.Collections.Generic;
using SDL2;
using DistantLands.Objects;
#endregion

namespace DistantLands.Graphics
{
#region Window Manager
    public class Window
    {
        public IntPtr Win;
        public IntPtr Renderer;
        public Array Objects;
        const int Fps = 20;
        const int FrameDelay = 100 / Fps;
        uint _frameStart;
        int _frameTime;
        public bool Running;
        SDL.SDL_WindowFlags _flags;
        
        #region Window Constructor DEFAULT
        public Window(int width, int height, bool fullscreen, string title)
        {
            if (fullscreen) { _flags = SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE; }
            Running = false;
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) == 0)
            {
                Win = SDL.SDL_CreateWindow(title,
                    SDL.SDL_WINDOWPOS_CENTERED,
                    SDL.SDL_WINDOWPOS_CENTERED,
                    width,
                    height,
                    _flags
                    );
                Renderer = SDL.SDL_CreateRenderer(Win, -1, 0);
                WinPass.Renderer = Renderer;
                // Check if window and render are still equal to null (IntPtr.Zero)
                if (Win != IntPtr.Zero)
                {
                    // Window true, check render
                    if (Renderer != IntPtr.Zero)
                    { Running = true; SDL.SDL_SetRenderDrawColor(Renderer, 0, 255, 0, 255); }
                    else { Running = false; }
                }
                else { Running = false; }

            }
            else { Running = false; }
        }
        #endregion
        
        #region Window Constructor position changed
        public Window(int width, int height, int xPos, int yPos, bool fullscreen, string title)
        {
            if (fullscreen) { _flags = SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE; }
            Running = false;
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) == 0)
            {
                Win = SDL.SDL_CreateWindow(title,
                    xPos,
                    yPos,
                    width,
                    height,
                    _flags
                );
                Renderer = SDL.SDL_CreateRenderer(Win, -1, 0);
                // Check if window and render are still equal to null (IntPtr.Zero)
                if (Win != IntPtr.Zero)
                {
                    // Window true, check render
                    if (Renderer != IntPtr.Zero)
                    { Running = true; SDL.SDL_SetRenderDrawColor(Renderer, 0, 255, 0, 255); }
                    else { Running = false; }
                }
                else { Running = false; }

            }
            else { Running = false; }
        }
        #endregion
        public void FrameCheck()
        {
            _frameStart = SDL.SDL_GetTicks();
            _frameTime = Convert.ToInt32(SDL.SDL_GetTicks()) - Convert.ToInt32(_frameStart);
            if (FrameDelay > _frameTime) { SDL.SDL_Delay(Convert.ToUInt32(FrameDelay) - Convert.ToUInt32(_frameTime)); }
        }
        public void HandleEvents()
        {
        }
        public void Update()
        {
            foreach (GameObject obj in WinPass.objects)
            {
                if (obj is Player)
                {
                    Player player = (Player)obj;
                    player.Update();
                    player.PlayerInput.QuitCheck();
                    player = null;
                } else if (obj is Enemy)
                {
                    Enemy enemy = (Enemy) obj;
                    enemy = null;
                } else if (obj is Item)
                {
                    Item item = (Item) obj;
                    item = null;
                }
                

            }
        }

        public void Render()
        {
            SDL.SDL_RenderClear(Renderer);
            foreach (GameObject obj in WinPass.objects)
            {
                obj.Render();
            }
            SDL.SDL_RenderPresent(Renderer);
        }
        public void Clean()
        {
            SDL.SDL_DestroyWindow(Win);
            SDL.SDL_DestroyRenderer(Renderer);
            SDL.SDL_Quit();
        }
    }
    #endregion

    public static class WinPass
    {

        public static IntPtr Renderer = IntPtr.Zero;
        public static List<GameObject> objects = new List<GameObject>();
    }
}