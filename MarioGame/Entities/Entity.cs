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
        protected AnimatedSprite _sprite { get; set; }
        
        public float _secondsOfInvincibilityRemaining { get; set; }//TODO: Get this logic out of the base entity class. And also to check if invincible use some Invincible property that returns true if the timer is greater than zero . . .do this to enable the user of the invincibility property to not have knowledge of how invcibility works (e.g. it uses a timer)
        public ActionState AState { get; set; }
        private bool _colliding;
        protected bool floating { get; set; }

        public Directions Direction
        {
            get; protected set;
        }
        public ActionState CurrentActionState => this.AState;
        //NOTE: Position and _position are deliberately not using the auto-generated property getter set
        private Vector2 _position;
        public float PositionX
        {
            get { return _position.X; }
            protected set { _position.X = value; }
        }
        public float PositionY
        {
            get { return _position.Y; }
            protected set { _position.Y = value; }
        }
        public Vector2 Position
        {
            get { return _position; }
            protected set { _position = value; }
        }
        public bool FacingLeft => Direction == Directions.Left;
        public bool FacingRight => Direction == Directions.Right;
        private Vector2 _velocity;
        public float VelocityX
        {
            get { return _velocity.X; }
            set { _velocity.X = value; }
        }
        public float VelocityY
        {
            get { return _velocity.Y; }
            set { _velocity.Y = value; }
        }
        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }
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
        protected Point BoundingBoxSize { get; set; }
        protected Point BoundingBoxOffset { get; set; } = new Point(0,0);
        private Color RegularBoxColor = Color.Yellow;
        private Color CollidingBoxColor = Color.Black;
        public float BoxPercentSizeOfEntity { get; set; } = 1.0f;
        public Color BoxColor { get; set; }

        private int _width => _sprite.FrameWidth;
        public int Width => _width;
        private int _height => _sprite.FrameHeight;
        public int Height => _height;
        public Action<Entity> AddToScriptEntities { get; set; }

        protected virtual void PreConstructor() {}

        public static Script Script { get; private set; }

        internal static void RegisterScript(Script s)
        {
            Script = s;
        }
        internal Entity(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities, float xVelocity = 0, float yVelocity = 0)
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
        //TODO: get rid of the below stamp coupling of JEntity and Game1
        internal virtual void Init(JEntity e, Game1 game)
        {
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
            if (Game1.playAsMario != true)
            {
                if (!(this is Mario))
                {
                    _position += Velocity;
                }
            }
            else
            {
                _position += Velocity;
            }
            if (!floating)
                VelocityY = MathHelper.Clamp(Velocity.Y + .05f, -4, 4);
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
            VelocityX = newVelocity.X;
        }

        public virtual void SetYVelocity(Vector2 newVelocity)
        {
            VelocityY = newVelocity.Y;
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
            //SetXVelocity(WalkingVelocity);
            //if (FacingLeft)
            //{
                //TODO: how does below line work
            //    SetXVelocity(Velocity * -1);
            //}
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

        protected virtual void OnCollideHiddenBlock(Block block, Sides side, Sides blockSide)
        {
            
        }
        protected virtual void OnCollideBlock(Block block, Sides side, Sides blockSide)
        {
            if (!block.IsVisible)
            {
                OnCollideHiddenBlock(block, side, blockSide);
                return;
            }

            switch (side)
            {
                case Sides.Left:
                case Sides.Right:
                    OnBlockSideCollision(side);
                    break;
                case Sides.Top:
                    OnBlockTopCollision(block);
                    break;
                case Sides.Bottom:
                    OnBlockBottomCollision(block);
                    break;
            }
        }

        protected virtual void OnBlockBottomCollision()
        {
            if (Velocity.Y > 0)
            {
                PositionY -= Velocity.Y;
                VelocityY = 0;
            }
        }
        protected virtual void OnBlockBottomCollision(Block block)
        {
            OnBlockBottomCollision();
        }
        protected virtual void OnBlockTopCollision()
        {
            if (VelocityY < 0)
            {
                PositionY -= 1.1f * Velocity.Y;
                VelocityY = 0;
            }

        }
        protected virtual void OnBlockTopCollision(Block block)
        {
            OnBlockTopCollision();
        }

        protected virtual void OnBlockSideCollision(Sides side) { }
    }
}
