#region Using Statements
using System;
using SDL2;
using DistantLands.Objects;
#endregion

namespace DistantLands.Graphics
{
    #region Texture
    
    /// <summary>
    ///     Collection of all methods related to texture management
    /// </summary>
    public static class Texture
    {
        
        public static IntPtr Set(string path)
        {
            IntPtr texture, surface;
            surface = SDL_image.IMG_Load(path);
            texture = SDL.SDL_CreateTextureFromSurface(WinPass.Renderer, surface);
            return texture;
        }
    }
    #endregion
}
