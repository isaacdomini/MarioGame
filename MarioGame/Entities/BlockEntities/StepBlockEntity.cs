
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MarioGame.Sprites.ItemSprites;

namespace MarioGame.Entities.BLockEntitiesEntities
{
    public class StepBlockEntity : BlockEntity
    {
        public StepBlockEntity(Vector2 position, StepBlockSprite sprite) : base(position, sprite)
        {
        }
    }
}
