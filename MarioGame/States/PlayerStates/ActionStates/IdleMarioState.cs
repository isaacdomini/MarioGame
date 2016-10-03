using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Entities;
using MarioGame.Sprites;

namespace MarioGame.States.PlayerStates
{
    class IdleMarioState : MarioActionState
    {
        public IdleMarioState(MarioEntity entity) : base(entity)
        {
            actionState = MarioActionStateEnum.Idle;
        }

        public override void Jump()
        {
            MarioActionState jumpState = new JumpingMarioState(marioEntity);
            jumpState.setDirection(this.direction);
            marioEntity.ChangeActionState(jumpState);
            marioEntity.SetVelocityToJumpingStraight();
            jumpState.Begin(this);

        }
        public override void Crouch()
        {
            if (marioEntity.PowerUpState.powerUpState == MarioPowerUpStateEnum.Standard)
            {
                MarioActionState fallingState = new FallingMarioState(marioEntity);
                fallingState.setDirection(this.direction);
                marioEntity.ChangeActionState(fallingState);
                marioEntity.SetVelocityToFalling();
                fallingState.Begin(this);
            }
            else
            {
                MarioActionState crouchState = new CrouchingMarioState(marioEntity);
                crouchState.setDirection(this.direction);
                marioEntity.ChangeActionState(crouchState);
                marioEntity.SetVelocityToFalling();
                crouchState.Begin(this);
            }

        }
        public override void MoveLeft()
        {
            if (this.isFacingLeft())
            {
                MarioActionState moveLeft = new WalkingMarioState(marioEntity);
                marioEntity.ChangeActionState(moveLeft);
                moveLeft.setDirection(this.direction);
                marioEntity.SetVelocityToWalk(Directions.Left);
                moveLeft.Begin(this);
            }
            else if (this.isFacingRight())
            {
                MarioActionState idleLeft = new IdleMarioState(marioEntity);
                marioEntity.ChangeActionState(idleLeft);
                idleLeft.turnLeft();
                marioEntity.SetVelocityToIdle();
                idleLeft.Begin(this);
            }

        }
        public override void MoveRight()
        {
            // Meaning idle mario is already facing right
            if (this.isFacingRight())
            {
                // Mario state is set to walking right
                MarioActionState moveRight = new WalkingMarioState(marioEntity);
                marioEntity.ChangeActionState(moveRight);
                moveRight.turnRight();
                marioEntity.SetVelocityToWalk(Directions.Right);
                moveRight.Begin(this);
            }
            // Meaning marion is facing left
            else if (this.isFacingLeft())
            {
                // Mario is idling facing the right
                MarioActionState idleLeft = new IdleMarioState(marioEntity);
                marioEntity.ChangeActionState(idleLeft);
                idleLeft.turnRight();
                marioEntity.SetVelocityToIdle();
                idleLeft.Begin(this);
            }

        }
    }
}
