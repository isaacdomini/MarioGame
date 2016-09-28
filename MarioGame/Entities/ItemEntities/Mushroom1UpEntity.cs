
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.ItemEntities
{
    public class Mushroom1UpEntity : Entity
    {
        // Could be useful for casting in certain circumstances
        public Mushroom1Up iSprite;
        public Viewport viewport;
        IEntity mushroom;
        ContentManager content;
        public Mushroom1UpEntity(Vector2 position) : base(position)
        {
            iSprite = new Mushroom1Up(mushroom, content, viewport);
        }
        public override void Update() { }
    }
}
