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
        protected ActionState aState;
        public ActionState ActionState
        {
            get { return this.aState; }
        }

        IState _state;
        protected ISprite _sprite;
        protected Vector2 _position;
        protected Vector2 _velocity;


        public Entity(Vector2 position, float xVelocity = 0, float yVelocity = 0)
        {
            _velocity = new Vector2(xVelocity, yVelocity);
            _position = position;
        }
        public virtual void ChangeState(State newstate)
        {
            throw new NotImplementedException();
        }

        public virtual void Update()
        {
            _position += _velocity;
        }

        public Vector2 getPosition()
        {
            return _position;
        }


    }
}
