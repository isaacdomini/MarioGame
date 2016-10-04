
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.ItemEntities
{
    public class Mushroom1UpEntity : Entity
    {
        // Could be useful for casting in certain circumstances
        ContentManager content;
        public Mushroom1UpEntity(Vector2 position, Mushroom1UpSprite sprite) : base(position, sprite)
        {
            int _height = 40;
            int _width = 20;
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, _width, _height);

        }
        public override void Update() { }
    }
}
