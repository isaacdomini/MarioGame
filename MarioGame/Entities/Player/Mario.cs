﻿using Microsoft.Xna.Framework;
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
        public bool Invincible { get { return CurrentPowerUpState is FireStarState || CurrentPowerUpState is StandardStarState || CurrentPowerUpState is SuperStarState; } }
        // Could be useful for casting in certain circumstances
        public MarioPowerUpState marioPowerUpState;
        public MarioActionState marioActionState;
        // TODO: maybe we don't have to give the casted variable a new name, but rather just use the new keyword and the subclass type
        public MarioSprite _marioSprite;
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

            _marioSprite = (MarioSprite) _sprite;
            direction = Directions.Right;
            spaceBarAction = SpaceBarAction.run;
            _height = standardBoundingBoxHeight;
            _width = standardBoundingBoxWidth;
            boundingBox = new Rectangle((int)(Position.X + 5), (int)(Position.Y + 16), _width, _height);
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
            if (marioPowerUpState is DeadState)
            {
                SetVelocityToIdle();// _velocity = idleVelocity;
            }
            
            if (Position.X < 0 || Position.X + _width > viewport.Width || Position.Y < 0 || Position.Y + _height > viewport.Height ){
                SetVelocityToIdle();
            }

            if (!(marioPowerUpState is StandardState) || !(marioPowerUpState is StandardStarState) )
            {

                boundingBox.X = (int)Position.X - 5;
                boundingBox.Y = (int)Position.Y;
            }
            if (marioPowerUpState is StandardState || marioPowerUpState is DeadState || marioPowerUpState is StandardStarState )
            {
                if (this.isFacingLeft() == true)
                {
                    boundingBox.X = (int)Position.X - 5;
                    boundingBox.Y = (int)Position.Y + 16;
                }
                else
                {
                    boundingBox.X = (int)Position.X + 5;
                    boundingBox.Y = (int)Position.Y + 16;
                }
            }
        }
        public bool checkMarioJumping()
        {
            return this.Velocity.Equals(jumpingVelocity);
        }
        public void ChangeActionState(MarioActionState state)
        {
            base.ChangeActionState(state);
            _marioSprite.changeActionState(state);
        }
        public void ChangePowerUpState(MarioPowerUpState state)
        {
            base.ChangePowerUpState(state);
            setBoundingBox(); 
            _marioSprite.changePowerUp(state);//TODO: can we push _marioSprite.changePowerUp inside of base.ChangePowerUpState, or will doing so lose the polymorphism (e.g. will it call AnimatedSprite.changePowerUp rather than _marioSprite.changePowerUp
        }
        private void setBoundingBox()
        {
            if (marioPowerUpState is SuperState || marioPowerUpState is SuperStarState || marioPowerUpState is SuperStarState || marioPowerUpState is FireStarState ) 
            {
                boundingBox.Width = superBoundingBoxWidth;
                boundingBox.Height = superBoundingBoxHeight;
            }
            else if (marioPowerUpState is StandardState || marioPowerUpState is DeadState || marioPowerUpState is StandardStarState)
            {
                boundingBox.Width = standardBoundingBoxWidth;
                boundingBox.Height = standardBoundingBoxHeight;
            }
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
            Console.WriteLine("mario.MoveLeft called");
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
        internal void onHitByEnemy()
        {
            marioPowerUpState.onHitByEnemy();
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
            _position -= Velocity;
            marioActionState.Halt();
        }
        private void onCollideEnemy(Enemy enemy, Sides side)
        {
            if (!Invincible && !enemy.Dead && side != Sides.Top){
                Halt();
                ChangeToDeadState();
            }
        }
        protected override void onBlockSideCollision()
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