using System;
using System.Numerics;
using SDL2;

namespace DistantEngine.Graphics
{
    public class TextureMap
    {
        private SDL.SDL_Rect _src, _dst;
        private readonly IntPtr _grass;
        private readonly IntPtr _dirt;
        private readonly IntPtr _water;
        private readonly int[,] _map = new int[20, 25];

        /// <summary>
        /// Example tile map
        /// </summary>
        private readonly int[,] _lvl1 =
        {
            {0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
        };

        /// <summary>
        /// Constructor. Set tile map types
        /// </summary>
        public TextureMap()
        {
            _dirt = Texture.Set("assets/dirt.png");
            _grass = Texture.Set("assets/grass.png");
            _water = Texture.Set("assets/water.png");
            Console.WriteLine(SDL.SDL_GetError());
            _dst.x = 0;
            _dst.y = 0;
            _src.w = _src.h = 192;
            _dst.w = _dst.h = 32;
            _src.x = _src.y = 0;
        }

        /// <summary>
        /// Load map array and set private variable.
        /// </summary>
        /// <param name="toLoad"></param>
        public void LoadMap(int[] toLoad)
        {
            
        }

        /// <summary>
        /// Draw loaded map to screen. Z-Index of 1
        /// </summary>
        public void DrawMap()
        {
            int type = 0;
            for (int row = 0; row < 25; ++row)
            {
                for (int column = 0; column < 20; ++column)
                {
                    type = _lvl1[row, column];
                    _dst.x = column * 32;
                    _dst.y = row * 32;
                    Console.WriteLine(_dst.x);
                    Console.WriteLine(_dst.y);

                    switch (type)
                    {
                        case 0:
                            Texture.Draw(_water, _src, _dst);
                            Console.WriteLine(SDL.SDL_GetError());
                            Console.WriteLine("water");
                            break;
                        case 1:
                            Texture.Draw(_dirt, _src, _dst);
                            break;
                        case 2:
                            Texture.Draw(_grass, _src, _dst);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}