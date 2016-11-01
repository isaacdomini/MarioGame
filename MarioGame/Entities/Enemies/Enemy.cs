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

        public Enemy(Vector2 position, ContentManager content) : base(position, content)
        {
            IsCollidable = true;
            IsDead = false;
            BoxPercentSizeOfEntity = .5f;
        }
        public override void Halt()
        {
            Position -= Velocity;
            EnemyActionState.Halt();
        }
        public override void OnCollide(IEntity otherObject, Sides side, Sides otherSide)
        {
            base.OnCollide(otherObject, side, otherSide);
            if (otherObject is Mario)
            {
                if (side == Sides.Top)
                {
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
    }
}
