
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.ItemEntities
{
    public class StarEntity : Entity
    {
        // Could be useful for casting in certain circumstances
        public Star iSprite;
        public Viewport viewport;
        IEntity star;
        ContentManager content;
        public StarEntity(Vector2 position) : base(position)
        {
            iSprite = new Star(star, content, viewport);
        }
        public override void Update() { }
    }
}
