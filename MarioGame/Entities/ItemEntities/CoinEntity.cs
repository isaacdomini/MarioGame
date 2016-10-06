
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.ItemEntities
{
    public class CoinEntity : Entity
    {
        public static Rectangle boundingBox;
        public static Color boxColor;


        public CoinEntity(Vector2 position, CoinsSprite sprite) : base(position, sprite)
        {
            int _height = 40;
            int _width = 20;
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, _width/2, _height/3);
            boxColor = Color.Green;
        }
        public override void Update() { }
    }
}
