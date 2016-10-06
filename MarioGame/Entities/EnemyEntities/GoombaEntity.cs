
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.EnemyEntities
{
    public class GoombaEntity : Entity
    {
        //Bounding Box color for sprint2
        public static Color boxColor;
        public static Rectangle boundingBox;

        public GoombaEntity(Vector2 position, Sprite sprite) : base(position, sprite)
	    {
            int _height = 40;
            int _width = 20;
            boundingBox = new Rectangle((int)(_position.X+3), (int)(_position.Y+5), _width/2, _height / 4);
            boxColor = Color.Red;
        }
        public override void Update()
        {
            _position += _velocity;
            boundingBox.X = (int)_position.X;
            boundingBox.Y = (int)_position.Y;
        }
    }

}
