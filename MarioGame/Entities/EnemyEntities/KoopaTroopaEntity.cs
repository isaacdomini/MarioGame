using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Entities.EnemyEntities
{
    class KoopaTroopaEntity : Entity
    {
	public KoopaTroopaEntity(Vector2 position, Sprite sprite) : base(position, sprite)
	{
            int _height = 40;
            int _width = 20;
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, _width, _height);
        }
        public override void Update()
        {
            _position += _velocity;
            boundingBox.X =(int) _position.X;
            boundingBox.Y = (int)_position.Y;
        }
    }
}
