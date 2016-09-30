
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.ItemEntities
{
    public class FireFlowerEntity : Entity
    {
        // Could be useful for casting in certain circumstances
        ContentManager content;
        public FireFlowerEntity(Vector2 position, FireFlowerSprite flowerSprite) : base(position, flowerSprite)
        {
        }
        public override void Update() { }
    }
}
