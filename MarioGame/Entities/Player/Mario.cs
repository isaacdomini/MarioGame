using Microsoft.Xna.Framework;
using MarioGame.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MarioGame.States;
using MarioGame.Core;
using MarioGame.States.BlockStates.PowerUpStates;
using MarioGame.Theming;
using System;

namespace MarioGame.Entities
{
    public class Mario : PowerUpEntity
    {
        private float secondsOfInvincibilityRemaining = 0.0f;
        public float jumpTimer = 0;
        public bool Invincible
        {
            get
            {
                if (secondsOfInvincibilityRemaining > 0 || pState is FireStarState || pState is StandardStarState || pState is SuperStarState)
                    return true;
                else
                    return false;
            }
        }
        // Could be useful for casting in certain circumstances
        public MarioPowerUpState marioPowerUpState { get { return (MarioPowerUpState)pState; } }
        public MarioActionState marioActionState { get { return (MarioActionState)aState; } }
        // TODO: maybe we don't have to give the casted variable a new name, but rather just use the new keyword and the subclass type
        public MarioSprite _marioSprite { get { return (MarioSprite)_sprite; } }
        private int _width;
        private int _height;

        // Velocity variables
        private readonly static Vector2 jumpingVelocity = new Vector2(0, velocityConstant * -1);
        private readonly static Vector2 dashVelocity = new Vector2(velocityConstant * 2, 0);

        private static int superBoundingBoxWidth = 20;
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

        MarioPowerUpStateMachine marioPowerUpStateMachine;

        public Mario(Vector2 position, ContentManager content) : base(position, content)
        {
            marioActionStateMachine = new MarioActionStateMachine(this);
            marioPowerUpStateMachine = new MarioPowerUpStateMachine(this);           
            aState = marioActionStateMachine.IdleMarioState; //TODO: make marioActionState a casted getter of aState?
            pState = marioPowerUpStateMachine.StandardState;

            direction = Directions.Right;
            spaceBarAction = SpaceBarAction.run;
            _height = standardBoundingBoxHeight;
            _width = standardBoundingBoxWidth;
        }
        protected override void setUpBoundingBoxProperties()
        {
            int sideMargin = 0, topBottomMargin = 0;
            if (marioPowerUpState is FireStarState || marioPowerUpState is SuperState || marioPowerUpState is FireState || marioPowerUpState is SuperStarState)
            {
                boundingBoxSize = new Point(superBoundingBoxWidth, superBoundingBoxHeight);
            }
            else
            {
                boundingBoxSize = new Point(standardBoundingBoxWidth, standardBoundingBoxHeight);
                topBottomMargin = 16;
            }
            boundingBoxOffset = new Point(sideMargin, topBottomMargin);
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
                if (secondsOfInvincibilityRemaining <= 0)
                {
                    OnInvincibilityEnded();
                }
            }
        }
        public override void Update(Viewport viewport, GameTime gameTime)
        {
            base.Update(viewport, gameTime);
            UpdateInvincibilityStatus();
            if (marioPowerUpState is DeadState)
            {
                SetVelocityToIdle();// _velocity = idleVelocity;
            }

            if(marioActionState is JumpingMarioState)
            {
                if (jumpTimer > 1.5)
                {
                    marioActionState.Fall();
                }
                jumpTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
        public void ChangeActionState(MarioActionState state)
        {
            base.ChangeActionState(state);
            _marioSprite.changeActionState(state);
        }
        public void ChangePowerUpState(MarioPowerUpState state)
        {
            base.ChangePowerUpState(state);
            LoadBoundingBox();
            _marioSprite.changePowerUp(state);//TODO: can we push _marioSprite.changePowerUp inside of base.ChangePowerUpState, or will doing so lose the polymorphism (e.g. will it call AnimatedSprite.changePowerUp rather than _marioSprite.changePowerUp
        }
        public void Jump()
        {
            if (!(marioPowerUpState is DeadState))
            {
                marioActionState.Jump();
            }
        }
        public void Crouch()
        {
            //TODO: make actionState take a StateFactory so the way we check pState and action State below can be consistent
            if (marioPowerUpState is StandardState && (marioActionState).actionState == MarioActionStateEnum.Idle)
            {
                marioActionState.Fall();
            }
            else if (!(marioPowerUpState is DeadState))
            {
                marioActionState.Crouch();
            }
        }
        public void MoveLeft()
        {
            if (!(marioPowerUpState is DeadState))
            {
                marioActionState.MoveLeft();
            }
        }
        public void MoveRight()
        {
            if (!(marioPowerUpState is DeadState))
            {
                marioActionState.MoveRight();
            }
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
        //Todo: I don't like that we have a method called DashOrThrowFireball. I think we should have a Dash() method and a throwFireball() method, and which one gets called gets handled in the State classes
        public void DashOrThrowFireball()
        {
            //TODO: Ricky do this?
            if (pState is FireState || pState is FireStarState)
            {
                // TODO: Mario entity adds fireball to scene

            }
            else if (pState is SuperState)
            {
                if (spaceBarAction == SpaceBarAction.walk)
                {
                    _velocity = Velocity / 2;
                    spaceBarAction = SpaceBarAction.run;
                }
                else if (spaceBarAction == SpaceBarAction.run)
                {
                    _velocity = Velocity * 2;
                    spaceBarAction = SpaceBarAction.walk;
                }
            }
        }
        
        public void SetVelocityToJumping()
        {
            this.setVelocity(jumpingVelocity);
        }
        public override void Halt()
        {
            _position -= Velocity;
            marioActionState.Halt();
        }
        private void onCollideEnemy(Enemy enemy, Sides side)
        {
            if (!Invincible)
            {
                if (!enemy.Dead && side != Sides.Bottom)
                {
                    marioPowerUpState.onHitByEnemy();
                }
                else
                {
                    Halt();
                }
            }
        }
        protected override void onBlockSideCollision()
        {
            _position.X -= 2 * Velocity.X;
            _velocity.X = 0;
            marioActionState.Halt();
        }
        public override void onBlockBottomCollision()
        {
            base.onBlockBottomCollision();
            Halt();
        }
        public override void onBlockTopCollision()
        {
            base.onBlockTopCollision();
            marioActionState.Fall();
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
            if (otherObject is Enemy)
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
