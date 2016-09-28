
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.ItemEntities
{
    public class GroundBlockEntity : Entity
    {
        // Could be useful for casting in certain circumstances
        ContentManager content;
        public GroundBlockEntity(Vector2 position, GroundBlockSprite sprite) : base(position, sprite)
        {
        }
        public override void Update() { }
    }
}
