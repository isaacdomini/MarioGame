using MarioGame.Entities.Blocks;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;

namespace MarioGame.Entities.Blocks
{
    internal class BrokenBrick : Block
    {
        public BrokenBrick(Vector2 position, Sprite sprite) : base(position, sprite)
        {
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, 18, 18);
            boxColor = Color.Blue;
        }
    }
}