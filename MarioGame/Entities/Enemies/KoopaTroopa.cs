using MarioGame.Collisions;
using MarioGame.Core;
using MarioGame.Sprites;
using MarioGame.States;
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

namespace MarioGame.Entities
{
    public class KoopaTroopa : Enemy
    {
        //public KoopaTroopaSprite eSprite;
        private KoopaActionState eState;
        public readonly static Vector2 movingVelocity = new Vector2(-1, 0);
        private int _height;
        private int _width;
        private static int boundingBoxWidth = 10;
        private static int boundingBoxHeight = 13;
        KoopaStateMachine _stateMachine;

        public KoopaTroopa(Vector2 position, ContentManager content) : base(position, content)
        {
            _stateMachine = new KoopaStateMachine(this);
            aState = _stateMachine.WalkState;
            eState = (KoopaActionState)aState;
            eSprite = (KoopaTroopaSprite)_sprite;
            boundingBox = new Rectangle((int)_position.X + 3, (int)_position.Y + 5, boundingBoxWidth, boundingBoxHeight);
            boxColor = Color.Red;
            isCollidable = true;
            _height = boundingBoxHeight;
            _width = boundingBoxWidth;
            _velocity = movingVelocity;
        }
        public void ChangeActionState(KoopaActionState newState)
        {
            eState = newState;
            ((KoopaTroopaSprite)eSprite).changeActionState(newState);
        }

        internal void SetShellVelocityToMoving()
        {
            this.setVelocity(movingVelocity);
        }
        public override void ChangeVelocityDirection()
        {
            Vector2 newVelocity = _velocity * -1;
            this.setVelocity(newVelocity);
            changeSpriteDirection();
        }

        public override void Halt()
        {
            _position -= _velocity;
            eState.Halt();
        }
        public override void JumpedOn()
        {
            eState.JumpedOn();
            _hurts = !_hurts;
        }

        public override void Update(Viewport viewport)
        {
            base.Update();
            Vector2 pos = _position;
            if (_position.X < 0)
            {
                pos.X = 0;
                ChangeVelocityDirection();
            }
            else if (_position.X + _width > viewport.Width)
            {
                pos.X = viewport.Width - _width;
                ChangeVelocityDirection();
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
        public void changeSpriteDirection()
        {
            ((KoopaActionState)eState).changeSpriteDirection();
        }
    }
}
