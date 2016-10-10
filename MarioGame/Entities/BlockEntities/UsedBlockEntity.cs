
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MarioGame.Entities.BlockEntities;
using MarioGame.Sprites.BlockSprites;

namespace MarioGame.Entities.BlockEntities
{
    public class UsedBlockEntity : BlockEntity
    {
        public UsedBlockEntity(Vector2 position, UsedBlockSprite sprite) : base(position, sprite)
        {
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, 18, 18);
            boxColor = Color.Blue;
        }
    }
}
