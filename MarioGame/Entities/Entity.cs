using MarioGame.Sprites;
using MarioGame.States;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.States.PlayerStates;

namespace MarioGame.Entities
{
    public abstract class Entity : IEntity
    {
        protected IState _state;
        protected ISprite _sprite;
        protected Vector2 _position;
        protected Vector2 _vertSpeed;
        protected Vector2 _horSpeed;
        protected enum Directions {
            Left = 1,
            Right = 2
        }
        protected enum Frames
        {
            //frames are all facing left. Except DeadMario who is facing the computer user.
            DeadMario = 1,
            FlyingMarioEnd = 2,
            FlyingMarioBeforeEnd = 3,
            FlyingMarioMiddle = 4,
            FlyingMarioAfterStart = 5,
            FlyingMarioStart = 6,
            SittingMario2 = 7,
            SittingMario1 = 8,
            JumpingMario = 9,
            UnkownAction3 = 10,
            WalkingMario3 = 11,
            WalkingMario2 = 12,
            WalkingMario1 = 13,
            StandingMario = 14

        }
        public virtual void ChangeState(MarioState newstate)
        {
            throw new NotImplementedException();
        }

        public virtual void Update()
        {
            throw new NotImplementedException();
        }
    }
}
