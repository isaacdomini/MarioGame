using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Entities.Enemies
{
    class KoopaTroopa : Entity
    {
        


        public KoopaTroopa(Vector2 position, Sprite sprite) : base(position, sprite)
	{
            int _height = 40;
            int _width = 20;
            boundingBox = new Rectangle((int)_position.X+3, (int)_position.Y+5, _width/2, _height/3);
            boxColor = Color.Red;

        }
        public override void Update()
        {
            _position += _velocity;
            boundingBox.X =(int) _position.X+3;
            boundingBox.Y = (int)_position.Y+5;
        }
    }
}
