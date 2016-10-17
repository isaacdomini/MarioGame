using MarioGame.Sprites;
using MarioGame.States;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.States.PlayerStates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public abstract class Entity : IEntity
    {
        IState _state;
        public AnimatedSprite _sprite;
        public Rectangle boundingBox;
        public Color boxColor;
        protected ActionState aState;
        public bool isCollidable;
        public enum Directions
        {
            Left = 1,
            Right = 2
        }
        public Directions direction
        {
            get; protected set;
        }

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
        

        public readonly static int velocityConstant = 1;
        private readonly static Vector2 walkingVelocity = new Vector2(velocityConstant * 1, 0);
        public readonly static Vector2 idleVelocity = new Vector2(0, 0);
        protected virtual void preConstructor() { }
        public Entity(Vector2 position, ContentManager content, float xVelocity = 0, float yVelocity = 0)
        {
            preConstructor();
            _velocity = new Vector2(xVelocity, yVelocity);

            String spriteClass = this.GetType().Name + "Sprite";
            string namespaceAndClass = typeof(Sprite).Namespace + "." + spriteClass;
            Type type = Type.GetType(namespaceAndClass);
           _sprite = (AnimatedSprite)Activator.CreateInstance(type, content);

            _position = position;
            _sprite.Position = _position;
        }
        public virtual void ChangeState(IState newstate)
        {
            throw new NotImplementedException();
        }
        public void ChangeActionState(ActionState state)
        {
            aState = state;
        }
        public virtual void Update()
        {
            _position += _velocity;
        }
        public virtual void Update(Viewport viewport) { }
        public Vector2 getPosition()
        {
            return _position;
        }
        public void setVelocity(Vector2 newVelocity)
        {
            _velocity = newVelocity;
        }
        public void SetVelocityToIdle()
        {
            this.setVelocity(idleVelocity);
        }
        public void SetVelocityToWalk()
        {
            this.setVelocity(walkingVelocity);
            if (direction == Directions.Left)
            {
                _velocity = _velocity * -1;
            }
        }
        public virtual void Halt() { }
        public void makeInvisible()
        {
            _sprite.Visible = true;
        }
        public void setDirection(Directions newDir)
        {
            direction = newDir;
        }
        public bool isFacingLeft()
        {
            return direction == Directions.Left;
        }
        public bool isFacingRight()
        {
            return direction == Directions.Right;
        }
        public virtual void turnLeft()
        {
            direction = Directions.Left;
            _sprite.changeDirection(direction);
        }
        public virtual void turnRight() {
            direction = Directions.Right;
            _sprite.changeDirection(direction);
        }

    }
}
