namespace DistantLands.Objects
{
    #region EnemyObject
    public class Enemy : GameObject
    {
        public GameObject Entity;
        public Enemy(string textureSheetPath, int xPos, int yPos, int refH, int refW) : base(textureSheetPath, xPos, yPos, refH, refW)
        {
        }
    }
    #endregion
}