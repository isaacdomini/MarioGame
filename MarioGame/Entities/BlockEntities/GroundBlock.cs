
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MarioGame.Sprites.ItemSprites;

namespace MarioGame.Entities.BLockEntitiesEntities
{
    public class GroundBlockEntity : BlockEntity
    {
        public GroundBlockEntity(Vector2 position, StepBlockSprite sprite) : base(position, sprite)
        {
        }
    }
}
