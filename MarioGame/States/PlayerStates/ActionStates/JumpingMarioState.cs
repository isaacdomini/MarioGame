using MarioGame.Entities;
using MarioGame.Entities.PlayerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.PlayerStates
{
    class JumpingMarioState : MarioActionState
    {
        public JumpingMarioState(MarioEntity entity) : base(entity)
        {
            actionState = MarioActionStateEnum.Jumping;
        }
        //TODO: need to add in behavior for jumping higher if you hold the jump button down.

        public override void Crouch()
        {
            MarioActionState idleState = new IdleMarioState(marioEntity);
            idleState.setDirection(this.direction);
            marioEntity.ChangeActionState(idleState);
            marioEntity.SetVelocityToIdle();
            idleState.Begin(this);
        }
        public override void MoveLeft()
        {
            if (this.direction == Directions.Left)
            {
                // Checks if Mario was previously jumping left
                if (marioEntity.checkMarioJumpLeft())
                {
                    MarioActionState walkingLeft = new WalkingMarioState(marioEntity);
                    walkingLeft.setDirection(Directions.Left);
                    marioEntity.ChangeActionState(walkingLeft);
                    // Sets mario to walking to the left
                    marioEntity.SetVelocityToWalk(Directions.Left);
                    walkingLeft.Begin(this);
                }
                // Checks if mario was previously jumping straight up
                else if (marioEntity.checkMarioJumpingUp())
                {
                    // Sets mario to jumping left  
                    MarioActionState jumpingLeft = new JumpingMarioState(marioEntity);
                    jumpingLeft.setDirection(Directions.Left);
                    marioEntity.ChangeActionState(jumpingLeft);
                    // velocity = new Vector2(-1, 1) essentially
                    marioEntity.SetVelocityToJumpingDiagonal(Directions.Left);
                    jumpingLeft.Begin(this);
                }

            }
            // Facing right jumping and told to move left now
            else if (this.direction == Directions.Right)
            {
                // Checking if mario was jumping straight up previously
                if (marioEntity._velocity == MarioEntity.jumpingUpVelocity)
                {
                    // Change mario to jumping up facing left now
                    MarioActionState jumpingUpFacingLeft = new JumpingMarioState(marioEntity);
                    jumpingUpFacingLeft.setDirection(Directions.Left);
                    marioEntity.ChangeActionState(jumpingUpFacingLeft);
                    marioEntity.SetVelocityToJumpingStraight();
                    jumpingUpFacingLeft.Begin(this);
                }
                // Checking if mario was jumping and moving to the right
                else if (marioEntity._velocity == MarioEntity.jumpingRightVelocity)
                {
                    MarioActionState walkingRight = new WalkingMarioState(marioEntity);
                    walkingRight.setDirection(Directions.Right);
                    marioEntity.ChangeActionState(walkingRight);
                    // Sets mario to jumping to the left
                    marioEntity.SetVelocityToWalk(Directions.Right);
                    walkingRight.Begin(this);
                }
            }

        }
        public override void MoveRight()
        {
            if (this.direction == Directions.Left)
            {
                // Checks if Mario was previously jumping left
                if (marioEntity._velocity == MarioEntity.jumpingLeftVelocity)
                {
                    MarioActionState walkingLeft = new WalkingMarioState(marioEntity);
                    walkingLeft.setDirection(Directions.Left);
                    marioEntity.ChangeActionState(walkingLeft);
                    // Sets mario to walking to the left
                    marioEntity.setVelocity(MarioEntity.walkingLeftVelocity);
                    marioEntity.SetVelocityToWalk(Directions.Left);
                    walkingLeft.Begin(this);
                }
                // Checks if mario was previously jumping straight up
                else if (marioEntity._velocity == MarioEntity.jumpingUpVelocity)
                {
                    // Sets mario to jumping straight up facing right  
                    MarioActionState jumpingUpFacingRight = new JumpingMarioState(marioEntity);
                    jumpingUpFacingRight.setDirection(Directions.Right);
                    marioEntity.ChangeActionState(jumpingUpFacingRight);
                    // velocity = new Vector2(0, 1) essentially
                    marioEntity.SetVelocityToJumpingStraight();
                    jumpingUpFacingRight.Begin(this);
                }

            }
            else if (this.direction == Directions.Right)
            {
                // Checking if mario was jumping straight up previously
                if (marioEntity._velocity == MarioEntity.jumpingUpVelocity)
                {
                    // Change mario to jumping right now
                    MarioActionState jumpingRight = new JumpingMarioState(marioEntity);
                    jumpingRight.setDirection(Directions.Right);
                    marioEntity.ChangeActionState(jumpingRight);
                    marioEntity.SetVelocityToJumpingDiagonal(Directions.Right);
                    jumpingRight.Begin(this);
                }
                // Checking if mario was jumping and moving to the right
                else if (marioEntity._velocity == MarioEntity.walkingRightVelocity)
                {
                    MarioActionState walkingRight = new WalkingMarioState(marioEntity);
                    walkingRight.setDirection(Directions.Right);
                    marioEntity.ChangeActionState(walkingRight);
                    // Sets mario to jumping to the left
                    marioEntity.SetVelocityToWalk(Directions.Right);
                    walkingRight.Begin(this);
                }
            }
        }
    }
}
