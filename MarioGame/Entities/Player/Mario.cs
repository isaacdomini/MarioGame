using Microsoft.Xna.Framework;
using MarioGame.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MarioGame.States;

namespace MarioGame.Entities
{
    public class Mario : PowerUpEntity
    {
        private MarioPowerUpState marioPowerUpState;
        public static int invincibleTiber=0;
        // Could be useful for casting in certain circumstances
        public MarioPowerUpState PowerUpState
        {
            get { return marioPowerUpState; }
        }
        public MarioSprite mSprite;
        private int _width;
        private int _height;

        // Velocity variables
        private readonly static Vector2 jumpingVelocity = new Vector2(0, velocityConstant * -1);
        private readonly static Vector2 fallingVelocity = new Vector2(0, velocityConstant * 1);
        private readonly static Vector2 dashVelocity = new Vector2(velocityConstant * 2, 0);

        private static int superBoundingBoxWidth = 30;
        private static int superBoundingBoxHeight = 36;

        private static int standardBoundingBoxWidth = 20;
        private static int standardBoundingBoxHeight = 20;
        private enum SpaceBarAction
        {
            walk,
            run
        }

        private SpaceBarAction spaceBarAction;

        MarioActionStateMachine marioActionStateMachine;

        MarioActionState marioActionState;

        MarioPowerUpStateMachine powerUpStateMachine;

        public Mario(Vector2 position, ContentManager content) : base(position, content)
        {
            direction = Directions.Right;
            spaceBarAction = SpaceBarAction.run;
            marioActionStateMachine = new MarioActionStateMachine(this);
            powerUpStateMachine = new MarioPowerUpStateMachine(this);
            aState = marioActionStateMachine.IdleMarioState;
            marioActionState = (MarioActionState)aState;
            pState = powerUpStateMachine.StandardState;
            marioPowerUpState = (MarioPowerUpState)pState; 
            // Now only cast once
            mSprite = (MarioSprite)_sprite;
            _height = standardBoundingBoxHeight;
            _width = standardBoundingBoxWidth;
            boundingBox = new Rectangle((int)(_position.X + 5), (int)(_position.Y + 16), _width, _height);
            boxColor = Color.Yellow;
        }

        public override void Update(Viewport viewport)
        {
            base.Update();
            // Maybe just set velocity to zero for all this? - Ricky
            Vector2 pos = _position;
            if (_position.X < 0)
            {
                pos.X = 0;
            }else if (_position.X + _width > viewport.Width)
            {
                pos.X = viewport.Width - _width;
            }
            if (_position.Y < 0)
            {
                pos.Y = 0;
            }else if (_position.Y + _height > viewport.Height)
            {
                pos.Y = viewport.Height - _height;
            }
            _position = pos;
            
            if(PowerUpState.powerUpState != MarioPowerUpStateEnum.Standard || PowerUpState.powerUpState != MarioPowerUpStateEnum.StandardStar)
            {
                
                boundingBox.X = (int)_position.X - 5;
                boundingBox.Y = (int)_position.Y;
            }
            if (PowerUpState.powerUpState == MarioPowerUpStateEnum.Standard || PowerUpState.powerUpState == MarioPowerUpStateEnum.Dead || PowerUpState.powerUpState == MarioPowerUpStateEnum.StandardStar)
            {
                if (this.isFacingLeft() == true)
                {
                    boundingBox.X = (int)_position.X - 5;
                    boundingBox.Y = (int)_position.Y + 16;
                }
                else
                {
                    boundingBox.X = (int)_position.X + 5;
                    boundingBox.Y = (int)_position.Y + 16;
                }
            }
        }
        public bool checkMarioJumping()
        {
            return this._velocity.Equals(jumpingVelocity);
        }

        public Vector2 position
        {
            get { return mSprite.Position; }
            set { mSprite.Position = value; }
        }

        public void ChangeActionState(MarioActionState state)
        {
            base.ChangeActionState(state);
            mSprite.changeActionState(state);

        }
        public void ChangePowerUpState(MarioPowerUpState state)
        {
            base.ChangePowerUpState(state);
            setBoundingBox(marioPowerUpState.powerUpState);
            mSprite.changePowerUp(marioPowerUpState);
        }
        private void setBoundingBox(MarioPowerUpStateEnum powerUpState)
        {
            if (powerUpState == MarioPowerUpStateEnum.Super || powerUpState == MarioPowerUpStateEnum.Fire || powerUpState == MarioPowerUpStateEnum.SuperStar || powerUpState == MarioPowerUpStateEnum.FireStar )
            {
                boundingBox.Width = superBoundingBoxWidth;
                boundingBox.Height = superBoundingBoxHeight;
            }
            else if (powerUpState == MarioPowerUpStateEnum.Standard || powerUpState == MarioPowerUpStateEnum.Dead || powerUpState == MarioPowerUpStateEnum.StandardStar)
            {
                boundingBox.Width = standardBoundingBoxWidth;
                boundingBox.Height = standardBoundingBoxHeight;
            }
        }


        public void Jump()
        {
            if (marioPowerUpState.powerUpState != MarioPowerUpStateEnum.Dead)
            {
                marioActionState.Jump();
            }
        }
        public void Crouch()
        {
            if (marioPowerUpState.powerUpState == MarioPowerUpStateEnum.Standard && ((MarioActionState)aState).actionState == MarioActionStateEnum.Idle)
            {
                marioActionState.Fall();
            }
            else if (marioPowerUpState.powerUpState != MarioPowerUpStateEnum.Dead)
            {
                marioActionState.Crouch();
            }
        }
        public void MoveLeft()
        {
            if (marioPowerUpState.powerUpState != MarioPowerUpStateEnum.Dead)
            {
                marioActionState.MoveLeft();
            }
        }
        public void MoveRight()
        {
            if (marioPowerUpState.powerUpState != MarioPowerUpStateEnum.Dead)
            {
                marioActionState.MoveRight();
            }
        }
        internal void EnemyHit()
        {
            marioPowerUpState.EnemyHit();
        }
        public void ChangeToFireState()
        {
            marioPowerUpState.ChangeToFire();
        }
        public void ChangeToStandardState()
        {
            marioPowerUpState.ChangeToStandard();
        }
        public void ChangeToSuperState()
        {
            marioPowerUpState.ChangeToSuper();
        }
        public void ChangeToStarState()
        {
            marioPowerUpState.ChangeToStar();
        }
        public void ChangeToDeadState()
        {
            marioPowerUpState.ChangeToDead();
        }
        public void DashOrThrowFireball()
        {
            //TODO: Ricky do this?
            if (marioPowerUpState.powerUpState == MarioPowerUpStateEnum.Fire)
            {
                // TODO: Mario entity adds fireball to scene

            }
            else if (marioPowerUpState.powerUpState == MarioPowerUpStateEnum.Super)
            {
                if (spaceBarAction == SpaceBarAction.walk)
                {
                    _velocity = _velocity / 2;
                    spaceBarAction = SpaceBarAction.run;
                }
                else if (spaceBarAction == SpaceBarAction.run)
                {
                    _velocity = _velocity * 2;
                    spaceBarAction = SpaceBarAction.walk;
                }
            }
        }
        public void SetVelocityToFalling()
        {
            this.setVelocity(fallingVelocity);
        }
        public void SetVelocityToJumping()
        {
            this.setVelocity(jumpingVelocity);
        }
        public override void Halt()
        {
            _position -= _velocity;
            marioActionState.Halt();
        }
    }
}
