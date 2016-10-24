using MarioGame.Sprites;
using MarioGame.States;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MarioGame.Core;
using MarioGame.States.BlockStates.PowerUpStates;

namespace MarioGame.Entities
{
    public abstract class Entity : IEntity, ICollidable
    {
        public AnimatedSprite _sprite;
        
        protected ActionState aState;
        public bool isCollidable;
        private bool _colliding;
        public Directions direction
        {
            get; protected set;
        }

        public ActionState CurrentActionState
        {
            get { return this.aState; }
        }

        protected Vector2 _position;
        public Vector2 Position
        {
            get { return _position; }
            protected set { _position = value; }
        }
        public bool FacingLeft { get { return direction == Directions.Left;  } }
        public bool FacingRight { get { return direction == Directions.Right; } }
        protected Vector2 _velocity;
        public Vector2 Velocity { get { return _velocity; } }
        public readonly static int velocityConstant = 1;
        private readonly static Vector2 walkingVelocity = new Vector2(velocityConstant * 1, 0);
        protected readonly static Vector2 fallingVelocity = new Vector2(0, velocityConstant * 1);
        public readonly static Vector2 idleVelocity = new Vector2(0, 0);
        public bool Moving { get { return !Velocity.Equals(idleVelocity); } }
        public bool Deleted { get; private set; }
        protected void Delete()
        {
            Deleted = true;
        }
        protected static int boundingBoxWidth = 10;
        public Rectangle boundingBox;
        protected Point boundingBoxSize;
        protected Point boundingBoxOffset = new Point(0,0);
        protected Color regularBoxColor = Color.Yellow;
        protected Color collidingBoxColor = Color.Black;
        protected float boxPercentSizeOfEntity = 1.0f;
        public Color BoxColor;
        protected virtual void preConstructor() {
        }
        public Entity(Vector2 position, ContentManager content, float xVelocity = 0, float yVelocity = 0)
        {
            preConstructor();
            _velocity = new Vector2(xVelocity, yVelocity);

            String spriteClass = this.GetType().Name + "Sprite";
            string namespaceAndClass = typeof(Sprite).Namespace + "." + spriteClass;
            Type type = Type.GetType(namespaceAndClass);
           _sprite = (AnimatedSprite)Activator.CreateInstance(type, content, this);

            _position = position;
            _colliding = false;
        }
        /** must be called after _sprite.Load() because boudningBoxSize reads from _sprite.FrameWidth/Height which aren't set until after _sprite.Load. LoadBoundingBox  is called in Scene. */
        public void LoadBoundingBox()
        {
            setUpBoundingBoxProperties();
            boundingBox = new Rectangle(Util.vectorToPoint(Position) + boundingBoxOffset, boundingBoxSize);
            BoxColor = regularBoxColor; 
        }
        protected virtual void setUpBoundingBoxProperties()
        {
            boundingBoxSize = new Point((int) (_sprite.FrameWidth * boxPercentSizeOfEntity), (int) (_sprite.FrameHeight * boxPercentSizeOfEntity));
            int sideMargin = (int) ((1.0f - boxPercentSizeOfEntity) / 2.0 * _sprite.FrameWidth);
            int topBottomMargin = (int)((1.0f - boxPercentSizeOfEntity) / 2.0 * _sprite.FrameHeight);
            boundingBoxOffset = new Point(sideMargin, topBottomMargin);
        }
        public void ChangeActionState(ActionState state)
        {
            aState = state;
        }
        public virtual void Update()
        {
            _position += Velocity;
            boundingBox.Location = Util.vectorToPoint(Position) + boundingBoxOffset;
            BoxColor = _colliding ? collidingBoxColor : regularBoxColor;
            _colliding = false;
        }
        public virtual void Update(Viewport viewport) { }
        public void setVelocity(Vector2 newVelocity)
        {
            _velocity = newVelocity;
        }
        public void SetVelocityToIdle()
        {
            setVelocity(idleVelocity);
        }
        public void SetVelocityToFalling()
        {
            setVelocity(fallingVelocity);
        }
        public void SetVelocityToWalk()
        {
            setVelocity(walkingVelocity);
            if (FacingLeft)
            {
                //TODO: how does below line work
                _velocity = Velocity * -1;
            }
        }
        public void makeInvisible()
        {
            _sprite.Visible = true;
        }
        public void setDirection(Directions newDir)
        {
            direction = newDir;
        }
        public virtual void flipHorizontalVelocity()
        {
            _velocity = -1 * _velocity;
        }
        public virtual void turnLeft() {
            direction = Directions.Left;
            _sprite.changeDirection(direction);
        }
        public virtual void turnRight() {
            direction = Directions.Right;
            _sprite.changeDirection(direction);
        }
        public virtual void Halt() { }

        /** onColide must be called before Update */
        public virtual void onCollide(IEntity otherObject, Sides side)
        {
            _colliding = true;
            if(otherObject is Block)
            {
                onCollideBlock((Block) otherObject, side);
            }
        }
        protected virtual void onCollideBlock(Block block, Sides side)
        {
            if (block.CurrentPowerUpState is HiddenState)
            {
                if (side == Sides.Top)
                {
                    Halt();
                }
            }
            else
            {
                if (side == Sides.Left || side == Sides.Right)
                {
                    onBlockSideCollision();
                }
                else if (side == Sides.Top)
                {
                    _position.Y -= Velocity.Y;
                    _velocity.Y = 0;
                }
                else if (side == Sides.Top)
                {
                    //TODO: replace the below with simply letting gravity take over
                    _position.Y -= Velocity.Y;
                    _velocity.Y = 0;
                }
            }
        }
        protected virtual void onBlockSideCollision() { }
    }
}
