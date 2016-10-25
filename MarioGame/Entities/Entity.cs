using MarioGame.Core;
using MarioGame.Sprites;
using MarioGame.States;
using MarioGame.States.BlockStates.PowerUpStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MarioGame.Entities
{
    public abstract class Entity : IEntity, ICollidable
    {
        public AnimatedSprite Sprite;
        
        protected ActionState AState;
        public bool IsCollidable;
        private bool _colliding;
        public Directions Direction
        {
            get; protected set;
        }

        public ActionState CurrentActionState
        {
            get { return this.AState; }
        }

        protected Vector2 _position;
        public Vector2 Position
        {
            get { return _position; }
            protected set { _position = value; }
        }
        public bool FacingLeft { get { return Direction == Directions.Left;  } }
        public bool FacingRight { get { return Direction == Directions.Right; } }
        protected Vector2 _velocity;
        public Vector2 Velocity { get { return _velocity; } }
        public static readonly int velocityConstant = 1;
        private readonly static Vector2 walkingVelocity = new Vector2(velocityConstant * 1, 0);
        protected readonly static Vector2 fallingVelocity = new Vector2(0, velocityConstant * 1);
        public readonly static Vector2 idleVelocity = new Vector2(0, 0);
        public bool Moving { get { return !Velocity.Equals(idleVelocity); } }
        public bool Deleted { get; private set; }
        protected void Delete()
        {
            Deleted = true;
            //_sprite.Visible = true;
        }
        protected static int BoundingBoxWidth = 10;
        public Rectangle BoundingBox;
        protected Point BoundingBoxSize;
        protected Point BoundingBoxOffset = new Point(0,0);
        protected Color RegularBoxColor = Color.Yellow;
        protected Color CollidingBoxColor = Color.Black;
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
           Sprite = (AnimatedSprite)Activator.CreateInstance(type, content, this);

            _position = position;
            _colliding = false;
        }
        /** must be called after _sprite.Load() because boudningBoxSize reads from _sprite.FrameWidth/Height which aren't set until after _sprite.Load. LoadBoundingBox  is called in Scene. */
        public virtual void LoadBoundingBox()
        {
            setUpBoundingBoxProperties();
            BoundingBox = new Rectangle(Util.VectorToPoint(Position) + BoundingBoxOffset, BoundingBoxSize);
            BoxColor = RegularBoxColor; 
        }
        protected virtual void setUpBoundingBoxProperties()
        {
            BoundingBoxSize = new Point((int) (Sprite.FrameWidth * boxPercentSizeOfEntity), (int) (Sprite.FrameHeight * boxPercentSizeOfEntity));
            int sideMargin = (int) ((1.0f - boxPercentSizeOfEntity) / 2.0 * Sprite.FrameWidth);
            int topBottomMargin = (int)((1.0f - boxPercentSizeOfEntity) / 2.0 * Sprite.FrameHeight);
            BoundingBoxOffset = new Point(sideMargin, topBottomMargin);
        }
        public virtual void ChangeActionState(ActionState state)
        {
            AState = state;
        }
        public virtual void Update(Viewport viewport, GameTime gameTime)
        {
            _position += Velocity;
            BoundingBox.Location = Util.VectorToPoint(Position) + BoundingBoxOffset;
            BoxColor = _colliding ? CollidingBoxColor : RegularBoxColor;
            _colliding = false;
        }
        public virtual void SetVelocity(Vector2 newVelocity)
        {
            _velocity = newVelocity;
        }
        public virtual void SetVelocityToIdle()
        {
            SetVelocity(idleVelocity);
        }
        public virtual void SetVelocityToFalling()
        {
            SetVelocity(fallingVelocity);
        }
        public virtual void SetVelocityToWalk()
        {
            SetVelocity(walkingVelocity);
            if (FacingLeft)
            {
                //TODO: how does below line work
                _velocity = Velocity * -1;
            }
        }
        public virtual void makeInvisible()
        {
            Sprite.Visible = true;
        }
        public virtual void setDirection(Directions newDir)
        {
            Direction = newDir;
        }
        public virtual void flipHorizontalVelocity()
        {
            _velocity = -1 * _velocity;
        }
        public virtual void turnLeft() {
            Direction = Directions.Left;
            Sprite.ChangeDirection(Direction);
        }
        public virtual void turnRight() {
            Direction = Directions.Right;
            Sprite.ChangeDirection(Direction);
        }
        public virtual void Halt() { }

        /** onColide must be called before Update */
        public virtual void OnCollide(IEntity otherObject, Sides side)
        {
            _colliding = true;
            if(otherObject is Block)
            {
                OnCollideBlock((Block) otherObject, side);
            }
        }
        protected virtual void OnCollideBlock(Block block, Sides side)
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
                    OnBlockSideCollision();
                }
                else if (side == Sides.Top)
                {
                    OnBlockTopCollision();

                }
                else if (side == Sides.Bottom)
                {
                    OnBlockBottomCollision();
                    //TODO: replace the below with simply letting gravity take over
                }
            }
        }

        public virtual void OnBlockBottomCollision()
        {
            _position.Y -= 2 * Velocity.Y;
            _velocity.Y = 0;
        }

        public virtual void OnBlockTopCollision()
        {
            _position.Y -= 2 * Velocity.Y;
            _velocity.Y = 0;
        }

        protected virtual void OnBlockSideCollision() { }
    }
}
