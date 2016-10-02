using MarioGame.Entities.BlockEntities;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;

namespace MarioGame.Entities.BlockEntities
{
    internal class BrokenBrickEntity : BlockEntity
    {
        public BrokenBrickEntity(Vector2 position, Sprite sprite) : base(position, sprite)
        {
        }
    }
}