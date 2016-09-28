
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MarioGame.Entities.BlockEntities;

namespace MarioGame.Entities.BLockEntitiesEntities
{
    public class UsedEntity : BlockEntity
    {
        public UsedEntity(Vector2 position, CoinsSprite sprite) : base(position, sprite)
        {
        }
    }
}
