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
        public Sprite _sprite;
        public Rectangle boundingBox;
        public Color boxColor;
        protected ActionState aState;
        public bool isCollidable;
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
        public readonly static Vector2 walkingRightVelocity = new Vector2(velocityConstant*1, 0);
        public readonly static Vector2 walkingLeftVelocity = new Vector2(velocityConstant *- 1, 0);
        public readonly static Vector2 idleVelocity = new Vector2(0, 0);
        protected virtual void preConstructor() { }
        public Entity(Vector2 position, ContentManager content, float xVelocity = 0, float yVelocity = 0)
        {
            preConstructor();
            _velocity = new Vector2(xVelocity, yVelocity);

            String spriteClass = this.GetType().Name + "Sprite";
            string namespaceAndClass = typeof(Sprite).Namespace + "." + spriteClass;
            Type type = Type.GetType(namespaceAndClass);
           _sprite = (Sprite)Activator.CreateInstance(type, content);

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
            aState.setDirection(state.direction);
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
        public virtual void Halt() { }
        public void makeInvisible()
        {
            _sprite.Visible = true;
        }

    }
}
