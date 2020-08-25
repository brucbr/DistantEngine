using System;


namespace DistantEngine.Objects
{
    public class Item : GameObject
    {
        public GameObject Entity;
        public Item(string textureSheetPath, int xPlayPos, int yPlayPos, int refH, int refW) : base(textureSheetPath, xPlayPos, yPlayPos, refH, refW)
        {
            
        }
        
    }
}