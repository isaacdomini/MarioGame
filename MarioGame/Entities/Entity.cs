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
        IState _state;
        public Sprite _sprite;
        public Rectangle boundingBox;

        protected ActionState aState;
        public ActionState ActionState
        {
            get { return this.aState; }
        }

        protected Vector2 _position
        {
            get { return _sprite.Position; }
            set { _sprite.Position = value; }
        }
        public Vector2 _velocity { get; protected set; }
        
        public Entity(Vector2 position, Sprite sprite, float xVelocity = 0, float yVelocity = 0)
        {
            _velocity = new Vector2(xVelocity, yVelocity);
            _sprite = sprite;
            _position = position;
            ((Sprite)_sprite).Position = _position;
        }
        public virtual void ChangeState(IState newstate)
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
        public void setVelocity(Vector2 newVelocity)
        {
            _velocity = newVelocity;
        }


    }
}
