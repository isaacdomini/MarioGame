
using System;
using MarioGame.Sprites.PlayerSprites;
using MarioGame.States;
using MarioGame.States.PlayerStates;
using MarioGame.States.PlayerStates.PowerUpStates;
using Microsoft.Xna.Framework;
using MarioGame.Sprites;
using Microsoft.Xna.Framework.Graphics;
using static MarioGame.States.PlayerStates.ActionState;
using MarioGame.Theming;
using MarioGame.Entities.BlockEntities;
using MarioGame.Collisions;

namespace MarioGame.Entities.PlayerEntities
{
    public class MarioEntity : Entity
    {
        private MarioPowerUpState pState;
        // Could be useful for casting in certain circumstances
        public MarioPowerUpState PowerUpState
        {
            get { return pState; }
        }
        public MarioSprite mSprite;
        private int _width;
        private int _height;

        // Velocity variables
        public readonly static int velocityConstant = 1;
        public readonly static Vector2 walkingRightVelocity = new Vector2(velocityConstant*1, 0);
        public readonly static Vector2 walkingLeftVelocity = new Vector2(velocityConstant *- 1, 0);
        public readonly static Vector2 idleVelocity = new Vector2(0, 0);
        public readonly static Vector2 jumpingUpVelocity = new Vector2(0, velocityConstant*-1);
        public readonly static Vector2 jumpingRightVelocity = new Vector2(velocityConstant*1, velocityConstant*-1);
        public readonly static Vector2 jumpingLeftVelocity = new Vector2(velocityConstant*- 1, velocityConstant*-1);
        public readonly static Vector2 fallingVelocity = new Vector2(0, velocityConstant*1);
        public readonly static Vector2 dashRightVelocity = new Vector2(velocityConstant * 2, 0);
        public readonly static Vector2 dashLeftVelocity = new Vector2(velocityConstant * -2, 0);


        public MarioEntity(Vector2 position, Sprite sprite) : base(position, sprite)
        {
            aState = new IdleMarioState(this);
            aState.turnRight();
            pState = new StandardState(this);
            // Now only cast once
            mSprite = (MarioSprite)_sprite;
            _height = 40;
            _width = 20;
            boundingBox= new Rectangle((int)(_position.X+5), (int)(_position.Y+16),_width,_width);
            boxColor = Color.Yellow;
        }



        public void Update(Viewport viewport)
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
            
            if(PowerUpState.powerUpState != MarioPowerUpStateEnum.Standard)
            {
                
                boundingBox.X = (int)_position.X - 5;
                boundingBox.Y = (int)_position.Y;
            }
            if (PowerUpState.powerUpState == MarioPowerUpStateEnum.Standard || PowerUpState.powerUpState == MarioPowerUpStateEnum.Dead)
            {
                if (ActionState.isFacingLeft() == true)
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
        public bool checkMarioJumpingUp()
        {
            return this._velocity.Equals(jumpingUpVelocity);
        }

        public bool checkMarioJumpLeft()
        {
            return this._velocity.Equals(jumpingLeftVelocity);
        }
        public bool checkMarioJumpRight()
        {
            return this._velocity.Equals(jumpingRightVelocity);
        }

        public Vector2 position
        {
            get { return mSprite.Position; }
            set { mSprite.Position = value; }
        }

        public void ChangeActionState(ActionState state)
        {
            aState = state;
            aState.setDirection(state.direction);
            
        }
        public void ChangePowerUpState(MarioPowerUpState state)
        {
            if (pState.powerUpState == MarioPowerUpStateEnum.Dead)
            {
                pState = state;

            }
            // TODO Is this all we need? Or do we need below methods
            pState = state;
        }

        public void Jump()
        {
            if (pState.powerUpState != MarioPowerUpStateEnum.Dead)
            {
                ((MarioActionState)aState).Jump();
            }
        }
        public void Crouch()
        {
            if (pState.powerUpState != MarioPowerUpStateEnum.Dead)
            {
                ((MarioActionState)aState).Crouch();
            }
        }
        public void WalkLeft()
        {
            if (pState.powerUpState != MarioPowerUpStateEnum.Dead)
            {
                ((MarioActionState)aState).MoveLeft();
            }
        }
        public void WalkRight()
        {
            if (pState.powerUpState != MarioPowerUpStateEnum.Dead)
            {
                ((MarioActionState)aState).MoveRight();
            }
        }
        public void ChangeToFireState()
        {
            pState.ChangeToFire();
        }
        public void ChangeToStandardState()
        {
            pState.ChangeToStandard();
        }
        public void ChangeToSuperState()
        {
            pState.ChangeToSuper();
        }
        public void ChangeToDeadState()
        {
            pState.ChangeToDead();
        }
        public void DashOrThrowFireball()
        {
            //TODO: Ricky do this?
            if (pState.powerUpState == MarioPowerUpStateEnum.Fire)
            {
                // TODO: Mario entity adds fireball to scene
            }
            else if (pState.powerUpState == MarioPowerUpStateEnum.Super)
            {
                if (_velocity == dashLeftVelocity)
                {
                    _velocity = walkingLeftVelocity;
                }
                else if (_velocity == dashRightVelocity)
                {
                    _velocity = walkingRightVelocity;
                }
                else if (_velocity == walkingLeftVelocity)
                {
                    _velocity = dashLeftVelocity;
                }
                else if (_velocity == walkingRightVelocity)
                {
                    _velocity = dashRightVelocity;
                }
            }
        }
        public void SetVelocityToFalling()
        {
            this.setVelocity(fallingVelocity);
        }
        public void SetVelocityToWalk(Directions dir)
        {
            if (dir == Directions.Left)
            {
                this.setVelocity(walkingLeftVelocity);
            }
            else if (dir == Directions.Right)
            {
                this.setVelocity(walkingRightVelocity);
            }
        }
        public void SetVelocityToIdle()
        {
            this.setVelocity(idleVelocity);
        }
        public void SetVelocityToJumpingDiagonal(Directions dir)
        {
            if (dir == Directions.Right)
            {
                this.setVelocity(jumpingRightVelocity);
            }
            else if (dir == Directions.Left)
            {
                this.setVelocity(jumpingLeftVelocity);
            }
        }
        public void SetVelocityToJumpingStraight()
        {
            this.setVelocity(jumpingUpVelocity);
        }
        public void Halt()
        {
            ((MarioActionState)aState).Halt();
        }
    }
}
