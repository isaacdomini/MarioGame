
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MarioGame.Sprites.BlockSprites;
using MarioGame.Entities.BlockEntities;

namespace MarioGame.Entities.BlockEntities
{
    public class HiddenBlockEntity : BlockEntity
    {
        public HiddenBlockEntity(Vector2 position, BrickBlockSprite sprite) : base(position, sprite)
        {
        }
    }
}
