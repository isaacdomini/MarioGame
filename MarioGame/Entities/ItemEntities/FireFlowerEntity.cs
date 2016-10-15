
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.ItemEntities
{
    public class FireFlowerEntity : Entity
    {


        public FireFlowerEntity(Vector2 position, FireFlowerSprite flowerSprite) : base(position, flowerSprite)
        {
            int _height = 40;
            int _width = 20;
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, _width, _height/2);
            boxColor = Color.Green;
        }
        public override void Update() { }
    }
}
