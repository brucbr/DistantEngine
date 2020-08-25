using System;
using System.Diagnostics;
using DistantLands.Graphics;

namespace DistantLands.Objects
{
    #region Player Object
    
    /// <summary>
    ///    Player class. Manages movement and updating of the player, while leaving basics to the GameObject class.
    /// </summary>
    public class Player : GameObject
    {
        public GameObject Entity;
        public readonly DistantLands.Input.Input PlayerInput;
        public Player(string textureSheetPath, int xPlayPos, int yPlayPos, int refH, int refW) : base(textureSheetPath, xPlayPos, yPlayPos, refH, refW)
        {
            PlayerInput = new DistantLands.Input.Input();
            WinPass.objects.Add(this);
        }
        
        private void Movement(int vertical, int horizontal, int speed)
        {
            UpdatePos(horizontal * speed, vertical * speed);
        }
        
        /// <summary>
        ///    Update all player related values to get ready for rendering.
        /// </summary>
        public void Update()
        {
            int v;
            int h;
            PlayerInput.ArrowKeys(out v, out h);
            Debugger.Log(1, "Movement", "V: " + Convert.ToString(v) + " H: " + Convert.ToString(h));
            Movement(v, h, speed: 4);
            UpdateGraphical();
        }
    }
    #endregion
}