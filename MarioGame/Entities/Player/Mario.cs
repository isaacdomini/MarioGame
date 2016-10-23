using Microsoft.Xna.Framework;
using MarioGame.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MarioGame.States;
using MarioGame.Core;
using MarioGame.States.BlockStates.PowerUpStates;
using MarioGame.Theming;

namespace MarioGame.Entities
{
    public class Mario : PowerUpEntity
    {
        private float secondsOfInvincibilityRemaining = 0.0f;
        public bool Invincible { get { return CurrentPowerUpState is FireStarState || CurrentPowerUpState is StandardStarState || CurrentPowerUpState is SuperStarState; } }
        // Could be useful for casting in certain circumstances
        public MarioPowerUpState marioPowerUpState;
        public MarioActionState marioActionState;
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

        MarioPowerUpStateMachine powerUpStateMachine;

        public Mario(Vector2 position, ContentManager content) : base(position, content)
        {
            marioPowerUpState = (MarioPowerUpState)pState;
            marioActionState = (MarioActionState)aState;
            marioActionStateMachine = new MarioActionStateMachine(this);
            powerUpStateMachine = new MarioPowerUpStateMachine(this);
            marioActionState = marioActionStateMachine.IdleMarioState;
            marioPowerUpState = powerUpStateMachine.StandardState;

            direction = Directions.Right;
            spaceBarAction = SpaceBarAction.run;
            _height = standardBoundingBoxHeight;
            _width = standardBoundingBoxWidth;
            boundingBox = new Rectangle((int)(_position.X + 5), (int)(_position.Y + 16), _width, _height);
            boxColor = Color.Yellow;
        }

        private void OnInvincibilityEnded()
        {
            if(marioPowerUpState is FireStarState)
            {
               ChangeToFireState();
            }
            else if (marioPowerUpState is StandardStarState)
            {
                ChangeToStandardState();
            }
            else if (marioPowerUpState is SuperStarState)
            {
                ChangeToSuperState();
            }
        }
        private void UpdateInvincibilityStatus()
        {
            if (secondsOfInvincibilityRemaining > 0)
            {
                secondsOfInvincibilityRemaining -= (GlobalConstants.MILLISECONDS_PER_FRAME / 1000);
                if (secondsOfInvincibilityRemaining < 0)
                {
                    OnInvincibilityEnded();
                }
            }
        }
        public override void Update(Viewport viewport)
        {
            base.Update();
            UpdateInvincibilityStatus();
            if (marioPowerUpState.powerUpState == MarioPowerUpStateEnum.Dead)
            {
                SetVelocityToIdle();// _velocity = idleVelocity;
            }
            
            if (_position.X < 0 || _position.X + _width > viewport.Width || _position.Y < 0 || _position.Y + _height > viewport.Height ){
                SetVelocityToIdle();
            }

            if (marioPowerUpState.powerUpState != MarioPowerUpStateEnum.Standard || marioPowerUpState.powerUpState != MarioPowerUpStateEnum.StandardStar)
            {

                boundingBox.X = (int)_position.X - 5;
                boundingBox.Y = (int)_position.Y;
            }
            if (marioPowerUpState.powerUpState == MarioPowerUpStateEnum.Standard || marioPowerUpState.powerUpState == MarioPowerUpStateEnum.Dead || marioPowerUpState.powerUpState == MarioPowerUpStateEnum.StandardStar)
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

        public void ChangeActionState(MarioActionState state)
        {
            base.ChangeActionState(state);
            ((MarioSprite)_sprite).changeActionState(state);

        }
        public void ChangePowerUpState(MarioPowerUpState state)
        {
            base.ChangePowerUpState(state);
            setBoundingBox(marioPowerUpState.powerUpState);
            ((MarioSprite)_sprite).changePowerUp(state);
        }
        private void setBoundingBox(MarioPowerUpStateEnum powerUpState)
        {
            if (powerUpState == MarioPowerUpStateEnum.Super || powerUpState == MarioPowerUpStateEnum.Fire || powerUpState == MarioPowerUpStateEnum.SuperStar || powerUpState == MarioPowerUpStateEnum.FireStar)
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
            if (marioPowerUpState.powerUpState == MarioPowerUpStateEnum.Standard && (marioActionState).actionState == MarioActionStateEnum.Idle)
            {
                (marioActionState).Fall();
            }
            else if (marioPowerUpState.powerUpState != MarioPowerUpStateEnum.Dead)
            {
                (marioActionState).Crouch();
            }
        }
        public void MoveLeft()
        {
            if (marioPowerUpState.powerUpState != MarioPowerUpStateEnum.Dead)
            {
                (marioActionState).MoveLeft();
            }
        }
        public void MoveRight()
        {
            if (marioPowerUpState.powerUpState != MarioPowerUpStateEnum.Dead)
            {
                (marioActionState).MoveRight();
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
        private void onCollideEnemy(Enemy enemy, Sides side)
        {
            if (!Invincible && !enemy.IsDead() && side != Sides.Bottom){
                Halt();
                ChangeToDeadState();
            }
        }
        private void onCollideBlock(Block block, Sides side)
        {
        }
        public override onBlockSideCollision()
        {
            Halt();
        }
        private void onCollideItem(Item item, Sides side)
        {
            if (item is Coin)
            {
                //Add code to add coin to total coins
            }
            else if (item is Star)
            {
                ChangeToStarState();
            }
            else if (item is FireFlower)
            {
                ChangeToFireState();
            }
            else if (item is Mushroom1Up)
            {
                //Add code to add extra life
            }
            else if (item is MushroomSuper)
            {
                ChangeToSuperState();
            }
        }
        public override void onCollide(IEntity otherObject, Sides side)
        {
            base.onCollide(otherObject, side);
            if (otherObject is Block)
            {
                onCollideBlock((Block)otherObject, side);
            }
            else if (otherObject is Enemy)
            {
                onCollideEnemy((Enemy)otherObject, side);
            }
            else if (otherObject is Item)
            {
                onCollideItem((Item)otherObject, side);
            }
       }
        public void setInvincible(float seconds)
        {
            secondsOfInvincibilityRemaining = seconds;
        }
    }

}