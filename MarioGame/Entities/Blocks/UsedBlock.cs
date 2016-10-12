
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MarioGame.Entities.Blocks;
using MarioGame.Sprites.BlockSprites;

namespace MarioGame.Entities.Blocks
{
    public class UsedBlock : Block
    {
        public UsedBlock(Vector2 position, UsedBlockSprite sprite) : base(position, sprite)
        {
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, 18, 18);
            boxColor = Color.Blue;
        }
    }
}
