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
