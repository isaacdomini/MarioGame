using MarioGame.Collisions;
using MarioGame.Core;
using MarioGame.Sprites;
using MarioGame.States.EnemyStates;
using MarioGame.States.PlayerStates;
using MarioGame.Theming;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Entities.EnemyEntities
{
    public class KoopaTroopa : Enemy
    {
        //public KoopaTroopaSprite eSprite;
        private KoopaActionState eState;
        public readonly static Vector2 movingVelocity = new Vector2(2, 0);
        private int _height;
        private int _width;

        public KoopaTroopa(Vector2 position, ContentManager content) : base(position, content)
        {
            aState = new WalkingKoopaState(this);
            eSprite = (KoopaTroopaSprite)_sprite;
            _height = 40;
            _width = 20;
            boundingBox = new Rectangle((int)_position.X + 3, (int)_position.Y + 5, _width / 2, _height / 3);
            boxColor = Color.Red;
            isCollidable = true;

        }

        internal void SetVelocityToMoving()
        {
            this.setVelocity(movingVelocity);
        }

        public override void Halt()
        {
            _position -= _velocity;
            ((KoopaActionState)aState).Halt();
        }
       
        public override void Update(Viewport viewport)
        {
            base.Update();
            Vector2 pos = _position;
            if (_position.X < 0)
            {
                pos.X = 0;
                _velocity = _velocity * -1;
            }
            else if (_position.X + _width > viewport.Width)
            {
                pos.X = viewport.Width - _width;
                _velocity = _velocity * -1;
            }
            _position = pos;

            //_position += _velocity;
            boundingBox.X = (int)_position.X + 3;
            boundingBox.Y = (int)_position.Y + 5;
        }
        public void ChangeToDeadState()
        {
            eState.ChangeToDead();
        }
    }
}
