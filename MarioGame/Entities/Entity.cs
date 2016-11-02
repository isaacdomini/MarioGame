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
        public AnimatedSprite Sprite => _sprite;

        protected AnimatedSprite _sprite;
        public float _secondsOfInvincibilityRemaining = 0.0f;
        protected ActionState AState;
        private bool _colliding;
        private bool _floating;
        protected bool floating { get { return _floating; } set { _floating = value; } }

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
        public virtual void Delete()
        {
            Deleted = true;
            
        }
        protected const int BoundingBoxWidth = 10;
        public Rectangle BoundingBox;
        protected Point BoundingBoxSize;
        private Point _boundingBoxOffset = new Point(0,0);
        protected Point BoundingBoxOffset { get { return _boundingBoxOffset; } set { _boundingBoxOffset = value; } }
        protected Color RegularBoxColor = Color.Yellow;
        protected Color CollidingBoxColor = Color.Black;
        public float BoxPercentSizeOfEntity = 1.0f;
        public Color BoxColor;
        public int Width => _sprite.FrameWidth;
        public int Height => _sprite.FrameHeight;
        protected Action<Entity> AddToScriptEntities;
        public Entity(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities, float xVelocity = 0, float yVelocity = 0)
        {
            _velocity = new Vector2(xVelocity, yVelocity);

            var spriteClass = this.GetType().Name + "Sprite";
            var namespaceAndClass = typeof(Sprite).Namespace + "." + spriteClass;
            var type = Type.GetType(namespaceAndClass);
            Debug.Assert(type != null, "type != null");
            _sprite = (AnimatedSprite)Activator.CreateInstance(type, content, this);

            _position = position;
            _colliding = false;
            floating = false;

            AddToScriptEntities = addToScriptEntities;
        }
        /** must be called after _sprite.Load() because boudningBoxSize reads from _sprite.FrameWidth/Height which aren't set until after _sprite.Load. LoadBoundingBox  is called in Scene. */
        public virtual void LoadBoundingBox()
        {
            SetUpBoundingBoxProperties();
            BoundingBox = new Rectangle(Util.VectorToPoint(Position) + BoundingBoxOffset, BoundingBoxSize);
            BoxColor = RegularBoxColor;
        }
        protected virtual void SetUpBoundingBoxProperties()
        {
            BoundingBoxSize = new Point((int) (Sprite.FrameWidth * BoxPercentSizeOfEntity), (int) (Sprite.FrameHeight * BoxPercentSizeOfEntity));
            var sideMargin = (int) ((1.0f - BoxPercentSizeOfEntity) / 2.0 * Sprite.FrameWidth);
            var topBottomMargin = (int)((1.0f - BoxPercentSizeOfEntity) * Sprite.FrameHeight);
            BoundingBoxOffset = new Point(sideMargin, topBottomMargin);
        }
        public virtual void ChangeActionState(ActionState state)
        {
            AState = state;
        }
        public virtual void Update(Viewport viewport, int elapsedMilliseconds)
        {
            _position += Velocity;
            if (!floating)
                _velocity.Y = MathHelper.Clamp(Velocity.Y + .05f, -4, 4);
            BoundingBox.Location = Util.VectorToPoint(Position) + BoundingBoxOffset;
            BoxColor = _colliding ? CollidingBoxColor : RegularBoxColor;
            _colliding = false;
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
        }
        public virtual void TurnRight() {
            Direction = Directions.Right;
        }

        public virtual void ChangeDirection()
        {
            Direction = FacingLeft ? Directions.Right : FacingRight ? Directions.Left : Directions.None;
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
        public virtual void OnCollide(IEntity otherObject, Sides ownSide, Sides otherSide)
        {
            _colliding = true;
            if(otherObject is Block)
            {
                OnCollideBlock((Block) otherObject, ownSide, otherSide);
            }
        }
        protected virtual void OnCollideBlock(Block block, Sides side, Sides blockSide)
        {
            if (!block.IsVisible)
            {
                if (this is Mario)
                {
                    if (side == Sides.Top && blockSide == Sides.Bottom && ((Mario)this).Velocity.Y < 0)
                    {
                        Halt();
                    }
                }
            }
            else
            {
                if (side == Sides.Left || side == Sides.Right)
                {
                    OnBlockSideCollision(side);
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

        protected virtual void OnBlockSideCollision(Sides side) { }
    }
}
