using System;
using DistantEngine.Graphics;
using SDL2;

namespace DistantEngine.Objects.Components
{
    public class SpriteComponent : IComp
    {
        public Vector2D Position;
        private IntPtr _tex;
        private SDL.SDL_Rect _src;
        public SDL.SDL_Rect Dst;
        public GameObject BaseObject;

        public SpriteComponent(){}

        /// <summary>
        /// Sprite Component constructor. Set ID. Set Parent.
        /// </summary>
        /// <param name="path"></param>
        public SpriteComponent(GameObject obj)
        {
            BaseObject = obj;
        }

        /// <summary>
        /// WILL FAIL (Intentional)
        /// An implementation of Initialise that satisfies IComp interface, while stating that you must provide arguments.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public void Initialise()
        {
            throw new ArgumentException();
        }

        /// <summary>
        /// Instantiate all values
        /// </summary>
        /// <param name="path">Path for image to load to texture</param>
        public void Initialise(string path, int sh, int sw, int dh, int dw)
        {
            Position = BaseObject.Position;
            _src.x = _src.y = 0;
            _src.h = sh;
            _src.w = sw;
            Dst.h = dh;
            Dst.w = dw;
            _tex = Texture.Set(path);
        }

        /// <summary>
        /// Method. Update function to be called at each frame.
        /// </summary>
        public void Update()
        {
            Position = BaseObject.Position;
            Dst.x = Convert.ToInt32(Position.x);
            Dst.y = Convert.ToInt32(Position.y);
        }

        /// <summary>
        /// Draw function to be called at each frame.
        /// </summary>
        public void Draw()
        {
            Texture.Draw(_tex, _src, Dst);
        }
    }
}