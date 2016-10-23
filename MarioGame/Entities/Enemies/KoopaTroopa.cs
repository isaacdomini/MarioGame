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
        public readonly static Vector2 shellMovingVelocity = new Vector2(2, 0);
        private int _height;
        private int _width;
        
        KoopaStateMachine _stateMachine;

        public KoopaTroopa(Vector2 position, ContentManager content) : base(position, content)
        {
            _stateMachine = new KoopaStateMachine(this);
            aState = _stateMachine.WalkState;
            eState = (KoopaActionState)aState;
            eSprite = (KoopaTroopaSprite)_sprite;
            regularBoxColor = Color.Red;
            isCollidable = true;

        }
        public void ChangeActionState(KoopaActionState newState)
        {
            eState = newState;
            ((KoopaTroopaSprite)eSprite).changeActionState(newState);
        }

        internal void SetShellVelocityToMoving()
        {
            this.setVelocity(shellMovingVelocity);
        }
        public void ChangeShellVelocityDirection()
        {
            Vector2 newVelocity = Velocity * -1;
            this.setVelocity(newVelocity);
        }

        public override void Halt()
        {
            Position-= Velocity;
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
            if (Position.X < 0)
            {
                _position.X = 0;
                ChangeShellVelocityDirection();
            }
            else if (Position.X + _width > viewport.Width)
            {
                _position.X = viewport.Width - _width;
                ChangeShellVelocityDirection();
            }
        
        }
        public void ChangeToDeadState()
        {
            eState.ChangeToDead();
        }
    }
}
