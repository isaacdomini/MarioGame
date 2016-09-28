
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
        ContentManager content;
        public StarEntity(Vector2 position, Star sprite) : base(position, sprite)
        {
            iSprite = new Star(content);
        }
        public override void Update() { }
    }
}
