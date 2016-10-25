using MarioGame.Core;
using MarioGame.Sprites;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;

namespace MarioGame.Entities
{
    public class Enemy : Entity
    {
        public AnimatedSprite EnemySprite => Sprite;
        protected EnemyActionState EnemyActionState => (EnemyActionState)AState;
        protected bool IsDead;
        public bool Dead => IsDead;
        private static readonly Vector2 FallingVelocity = new Vector2(0, VelocityConstant * 1);

        public Enemy(Vector2 position, ContentManager content) : base(position, content)
        {
            IsDead = false;
            BoxPercentSizeOfEntity = .8f;
        }
        public override void Halt()
        {
            Position -= Velocity;
            EnemyActionState.Halt();
        }
        public override void OnCollide(IEntity otherObject, Sides side)
        {
            base.OnCollide(otherObject, side);
            if (otherObject is Mario )
            {
                if (side == Sides.Top)
                {
                    IsDead = !IsDead;
                    EnemyActionState.JumpedOn(side); 
                }
                if (IsDead && (side == Sides.Left || side == Sides.Right))
                {
                    IsDead = !IsDead;
                    EnemyActionState.JumpedOn(side);
                }
            }
            if(otherObject is Block)
            {
                if(side == Sides.Left || side == Sides.Right)
                {
                    if(side == Sides.Left)
                    {
                        TurnRight();
                    }else
                    {
                        TurnLeft();
                    }
                    EnemyActionState.HitBlock();
                }
            }
        }
        public void ChangeToDeadState()
        {
            EnemyActionState.ChangeToDead();
        }
        public virtual void ChangeVelocityDirection() { }
    }
}
