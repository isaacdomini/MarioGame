
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.ItemEntities
{
    public class FireFlowerEntity : Entity
    {
        // Could be useful for casting in certain circumstances
        public FireFlower iSprite;
        public Viewport viewport;
        IEntity fireFlower;
        ContentManager content;
        public FireFlowerEntity(Vector2 position) : base(position)
        {
            iSprite = new FireFlower(fireFlower, content, viewport);
        }
        public override void Update() { }
    }
}
