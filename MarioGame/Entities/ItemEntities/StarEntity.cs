
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.ItemEntities
{
    public class StarEntity : Entity
    {
        // Could be useful for casting in certain circumstances
        public StarSprite iSprite;
        ContentManager content;

        public StarEntity(Vector2 position, StarSprite sprite) : base(position, sprite)
        {
            iSprite = new StarSprite(content);
            int _height = 40;
            int _width = 20;
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, _width*3/4, _height / 2);
            boxColor = Color.Green;
        }
        public override void Update() { }
    }
}
