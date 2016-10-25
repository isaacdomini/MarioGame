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
        protected KoopaTroopaSprite _koopaTroopaSprite { get { return (KoopaTroopaSprite)EnemySprite; } }
        //public KoopaTroopaSprite eSprite;
        public static Vector2 shellMovingVelocity = new Vector2(2, 0);
        private int _height;
        private int _width;
        
        KoopaStateMachine _stateMachine;

        public KoopaTroopa(Vector2 position, ContentManager content) : base(position, content)
        {
            _stateMachine = new KoopaStateMachine(this);
            ChangeActionState(_stateMachine.WalkState);
            AState.Begin(AState);
            IsCollidable = true;
        }
        //TODO: couldn't we delete this method and just let the parent method be used?
        public void ChangeActionState(KoopaActionState newState)
        {
            AState = newState;
            _koopaTroopaSprite.changeActionState(newState);
        }

        internal void SetShellVelocityToMoving()
        {
            this.SetVelocity(shellMovingVelocity);
        }
        public void ChangeShellVelocityDirection()
        {
            Vector2 newVelocity = Velocity * -1;
            this.SetVelocity(newVelocity);
        }
        public override void Update(Viewport viewport, GameTime gameTime)
        {
            base.Update(viewport, gameTime);
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
    }
}
