using MarioGame.Core;
using MarioGame.Sprites;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using MarioGame.Entities.Player;

namespace MarioGame.Entities
{
    public class Enemy : HidableEntity
    {
        public AnimatedSprite EnemySprite => Sprite;
        protected EnemyActionState EnemyActionState => (EnemyActionState)AState;
        public Enemy(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
        {
            _isVisible = true;
            BoxPercentSizeOfEntity = .5f;
        }
        public override void Halt()
        {
            Position -= Velocity;
            EnemyActionState.Halt();
        }

        public virtual void OnCollideMario(Mario otherObject, Sides side)
        {
            EnemyActionState.JumpedOn(side);
        }
        public override void OnCollide(IEntity otherObject, Sides side, Sides otherSide)
        {
            base.OnCollide(otherObject, side, otherSide);
            if (otherObject is Mario)
            {
                OnCollideMario((Mario)otherObject, side);
            }
            else if (otherObject is Fireball)
            {
                EnemyActionState.ChangeToDead();
            }
            else if (otherObject is Block)
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
        public override void Delete()
        {
            Hide();
            base.Delete();
        }
    }
}
