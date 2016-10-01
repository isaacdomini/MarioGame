﻿using MarioGame.Sprites;
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
        // Ricky: What is the difference between aState and ActionState and _state?
        protected ActionState aState;
        public ActionState ActionState
        {
            get { return this.aState; }
        }

        IState _state;
        public ISprite _sprite;
        protected Vector2 _position;
        public Vector2 _velocity { get; private set; }
        
        public Entity(Vector2 position, ISprite sprite, float xVelocity = 0, float yVelocity = 0)
        {
            _velocity = new Vector2(xVelocity, yVelocity);
            _position = position;
            _sprite = sprite;
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