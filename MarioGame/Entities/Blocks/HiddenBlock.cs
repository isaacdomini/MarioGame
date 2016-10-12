
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MarioGame.Sprites.BlockSprites;
using MarioGame.Entities.Blocks;

namespace MarioGame.Entities.Blocks
{
    public class HiddenBlock : Block
    {
        public HiddenBlock(Vector2 position, BrickBlockSprite sprite) : base(position, sprite)
        {
        }
    }
}
