using MarioGame.Entities.BlockEntities;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;

namespace MarioGame.Entities.BlockEntities
{
    internal class BrokenBrickEntity : BlockEntity
    {
        public BrokenBrickEntity(Vector2 position, Sprite sprite) : base(position, sprite)
        {
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, 18, 18);
            boxColor = Color.Blue;
        }
    }
}