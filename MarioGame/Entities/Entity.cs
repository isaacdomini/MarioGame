using MarioGame.Core;
using MarioGame.Sprites;
using MarioGame.States;
using MarioGame.Theming;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace MarioGame.Entities
{
    public abstract class Entity : IEntity, ICollidable
    {
        public AnimatedSprite Sprite
        {
            get { return _sprite; }
        }

        protected AnimatedSprite _sprite;
        
        protected ActionState AState;
        public bool IsCollidable;
        private bool _colliding;
        protected bool floating;
        public bool _isVisible=true;
        public Directions Direction
        {
            get; protected set;
        }
        public ActionState CurrentActionState => this.AState;

        protected Vector2 _position;
        public Vector2 Position
        {
            get { return _position; }
            protected set { _position = value; }
        }
        public bool FacingLeft => Direction == Directions.Left;
        public bool FacingRight => Direction == Directions.Right;
        protected Vector2 _velocity;
        public Vector2 Velocity { get { return _velocity; } }
        public static readonly int VelocityConstant = 1;
        private static readonly Vector2 WalkingVelocity = new Vector2(VelocityConstant * 1, 0);
        protected static readonly Vector2 fallingVelocity = new Vector2(0, VelocityConstant * 1);
        public static readonly Vector2 IdleVelocity = new Vector2(0, 0);
        public bool Moving => !Velocity.Equals(IdleVelocity);
        public bool Deleted { get; private set; }
        public void Delete()
        {
            Deleted = true;
            _isVisible = false;
        }
        protected static int BoundingBoxWidth = 10;
        public Rectangle BoundingBox;
        protected Point BoundingBoxSize;
        protected Point BoundingBoxOffset = new Point(0,0);
        protected Color RegularBoxColor = Color.Yellow;
        protected Color CollidingBoxColor = Color.Black;
        public float BoxPercentSizeOfEntity = 1.0f;
        public Color BoxColor;
        protected virtual void PreConstructor() {
        }
        public Entity(Vector2 position, ContentManager content, float xVelocity = 0, float yVelocity = 0)
        {
            PreConstructor();
            _velocity = new Vector2(xVelocity, yVelocity);

            var spriteClass = this.GetType().Name + "Sprite";
            var namespaceAndClass = typeof(Sprite).Namespace + "." + spriteClass;
            var type = Type.GetType(namespaceAndClass);
            Debug.Assert(type != null, "type != null");
            _sprite = (AnimatedSprite)Activator.CreateInstance(type, content, this);

            _position = position;
            _colliding = false;
            floating = false;
        }
        /** must be called after _sprite.Load() because boudningBoxSize reads from _sprite.FrameWidth/Height which aren't set until after _sprite.Load. LoadBoundingBox  is called in Scene. */
        public virtual void LoadBoundingBox()
        {
            {
                SetUpBoundingBoxProperties();
                BoundingBox = new Rectangle(Util.VectorToPoint(Position) + BoundingBoxOffset, BoundingBoxSize);
                BoxColor = RegularBoxColor;
            }
        }
        protected virtual void SetUpBoundingBoxProperties()
        {
            BoundingBoxSize = new Point((int) (Sprite.FrameWidth * BoxPercentSizeOfEntity), (int) (Sprite.FrameHeight * BoxPercentSizeOfEntity));
            var sideMargin = (int) ((1.0f - BoxPercentSizeOfEntity) / 2.0 * Sprite.FrameWidth);
            var topBottomMargin = (int)((1.0f - BoxPercentSizeOfEntity)/2 * Sprite.FrameHeight);
            BoundingBoxOffset = new Point(sideMargin, topBottomMargin);
        }
        public virtual void ChangeActionState(ActionState state)
        {
            AState = state;
        }
        public virtual void Update(Viewport viewport, GameTime gameTime)
        {
            if (_isVisible)
            {
                _position += Velocity;
                if (!floating)
                    _velocity.Y = MathHelper.Clamp(Velocity.Y + .05f, -4, 4);
                BoundingBox.Location = Util.VectorToPoint(Position) + BoundingBoxOffset;
                BoxColor = _colliding ? CollidingBoxColor : RegularBoxColor;
                _colliding = false;
            }
        }
        public virtual void SetVelocity(Vector2 newVelocity)
        {
            SetXVelocity(newVelocity);
            SetYVelocity(newVelocity);
        }

        public virtual void SetXVelocity(Vector2 newVelocity)
        {
            _velocity.X = newVelocity.X;
        }

        public virtual void SetYVelocity(Vector2 newVelocity)
        {
            _velocity.Y = newVelocity.Y;
        }
        public virtual void SetVelocityToIdle()
        {
            SetVelocity(IdleVelocity);
        }
        public virtual void SetVelocityToFalling()
        {
            SetYVelocity(fallingVelocity);
        }
        public virtual void SetVelocityToWalk()
        {
            SetXVelocity(WalkingVelocity);
            if (FacingLeft)
            {
                //TODO: how does below line work
                SetXVelocity(Velocity * -1);
            }
        }
        public virtual void FlipHorizontalVelocity()
        {
            _velocity = -1 * _velocity;
        }
        public virtual void TurnLeft() {
            Direction = Directions.Left;
            Sprite.ChangeDirection(Direction);
        }
        public virtual void TurnRight() {
            Direction = Directions.Right;
            Sprite.ChangeDirection(Direction);
        }
        public virtual void Halt() { }

        public virtual void HaltX()
        {
            SetXVelocity(Vector2.Zero);
        }

        public virtual void HaltY()
        {
            SetYVelocity(Vector2.Zero);
        }

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
            if (!block.IsVisible)
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
            if (Velocity.Y > 0)
            {
                _position.Y -= 1.1f*Velocity.Y;
                _velocity.Y = 0;
            }
        }

        public virtual void OnBlockTopCollision()
        {
            _position.Y -= 1.1f * Velocity.Y;
            _velocity.Y = 0;
        }

        protected virtual void OnBlockSideCollision() { }
    }
}
