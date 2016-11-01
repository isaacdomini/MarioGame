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
        protected KoopaTroopaSprite KoopaTroopaSprite => (KoopaTroopaSprite) EnemySprite;
        protected KoopaActionState KoopaActionState => (KoopaActionState) EnemyActionState;
        //public KoopaTroopaSprite eSprite;
        public static Vector2 ShellMovingVelocity = new Vector2(2, 0);

        public KoopaTroopa(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content,addToScriptEntities)
        {
            var stateMachine = new KoopaStateMachine(this);
            ChangeActionState(stateMachine.WalkingState);
            AState.Begin(AState);
        }
        //TODO: couldn't we delete this method and just let the parent method be used?
        public void ChangeActionState(KoopaActionState newState)
        {
            AState = newState;
            KoopaTroopaSprite.changeActionState(newState);
        }

        internal void SetShellVelocityToMoving()
        {
            this.SetVelocity(ShellMovingVelocity);
        }
        public void ChangeShellVelocityDirection()
        {
            var newVelocity = Velocity * -1;
            this.SetVelocity(newVelocity);
        }
        public override void Update(Viewport viewport, GameTime gameTime)
        {
            base.Update(viewport, gameTime);
            if (Position.X < 0)
            {
                _position.X = 0;
                ChangeShellVelocityDirection();
                TurnRight();
            }
            /*else if (Position.X + _width > viewport.Width)
            {
                _position.X = viewport.Width - _width;
                ChangeShellVelocityDirection();
                TurnLeft();
            }*/
        }

        public override void OnCollide(IEntity otherObject, Sides side, Sides otherSide)
        {
            base.OnCollide(otherObject, side, otherSide);
            if (otherObject is Mario)
            {
                KoopaActionState.HitByMarioSide();
            }
        }
    }
}