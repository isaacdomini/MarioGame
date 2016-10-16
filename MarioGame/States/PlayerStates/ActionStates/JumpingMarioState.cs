﻿using MarioGame.Entities.Players;

namespace MarioGame.States.PlayerStates
{
    class JumpingMarioState : MarioActionState
    {
        public JumpingMarioState(Mario entity) : base(entity)
        {
            actionState = MarioActionStateEnum.Jumping;
        }
        //TODO: need to add in behavior for jumping higher if you hold the jump button down.
        public override void Begin(MarioActionState prevState)
        {
            base.Begin(prevState);
            mario.SetVelocityToJumpingStraight();
        }

        public override void Crouch()
        {
            MarioActionState idleState = new IdleMarioState(mario);
            idleState.setDirection(this.direction);
            mario.ChangeActionState(idleState);
            mario.SetVelocityToIdle();
            idleState.Begin(this);
        }
        public override void MoveLeft()
        {
            if (this.isFacingLeft())
            {
                // Checks if Mario was previously jumping left
                if (mario.checkMarioJumpLeft())
                {
                    MarioActionState walkingLeft = new WalkingMarioState(mario);
                    walkingLeft.turnLeft();
                    mario.ChangeActionState(walkingLeft);
                    // Sets mario to walking to the left
                    mario.SetVelocityToWalk(Directions.Left);
                    walkingLeft.Begin(this);
                }
                // Checks if mario was previously jumping straight up
                else if (mario.checkMarioJumpingUp())
                {
                    // Sets mario to jumping left  
                    MarioActionState jumpingLeft = new JumpingMarioState(mario);
                    jumpingLeft.turnLeft();
                    mario.ChangeActionState(jumpingLeft);
                    // velocity = new Vector2(-1, 1) essentially
                    mario.SetVelocityToJumpingDiagonal(Directions.Left);
                    jumpingLeft.Begin(this);
                }

            }
            // Facing right jumping and told to move left now
            else if (this.isFacingRight())
            {
                // Checking if mario was jumping straight up previously
                if (mario._velocity == Mario.jumpingUpVelocity)
                {
                    // Change mario to jumping up facing left now
                    MarioActionState jumpingUpFacingLeft = new JumpingMarioState(mario);
                    jumpingUpFacingLeft.turnLeft();
                    mario.ChangeActionState(jumpingUpFacingLeft);
                    mario.SetVelocityToJumpingStraight();
                    jumpingUpFacingLeft.Begin(this);
                }
                // Checking if mario was jumping and moving to the right
                else if (mario._velocity == Mario.jumpingRightVelocity)
                {
                    MarioActionState walkingRight = new WalkingMarioState(mario);
                    walkingRight.turnRight();
                    mario.ChangeActionState(walkingRight);
                    // Sets mario to jumping to the left
                    mario.SetVelocityToWalk(Directions.Right);
                    walkingRight.Begin(this);
                }
            }

        }
        public override void MoveRight()
        {
            if (this.isFacingLeft())
            {
                // Checks if Mario was previously jumping left
                if (mario.checkMarioJumpLeft())
                {
                    MarioActionState walkingLeft = new WalkingMarioState(mario);
                    walkingLeft.turnLeft();
                    mario.ChangeActionState(walkingLeft);
                    // Sets mario to walking to the left
                    mario.setVelocity(Mario.walkingLeftVelocity);
                    mario.SetVelocityToWalk(Directions.Left);
                    walkingLeft.Begin(this);
                }
                // Checks if mario was previously jumping straight up
                else if (mario.checkMarioJumpingUp())
                {
                    // Sets mario to jumping straight up facing right  
                    MarioActionState jumpingUpFacingRight = new JumpingMarioState(mario);
                    jumpingUpFacingRight.turnRight();
                    mario.ChangeActionState(jumpingUpFacingRight);
                    // velocity = new Vector2(0, 1) essentially
                    mario.SetVelocityToJumpingStraight();
                    jumpingUpFacingRight.Begin(this);
                }

            }
            else if (this.isFacingRight())
            {
                // Checking if mario was jumping straight up previously
                if (mario.checkMarioJumpingUp())
                {
                    // Change mario to jumping right now
                    MarioActionState jumpingRight = new JumpingMarioState(mario);
                    jumpingRight.turnRight();
                    mario.ChangeActionState(jumpingRight);
                    mario.SetVelocityToJumpingDiagonal(Directions.Right);
                    jumpingRight.Begin(this);
                }
                // Checking if mario was jumping and moving to the right
                else if (mario.checkMarioJumpRight())
                {
                    MarioActionState walkingRight = new WalkingMarioState(mario);
                    walkingRight.turnRight();
                    mario.ChangeActionState(walkingRight);
                    // Sets mario to jumping to the left
                    mario.SetVelocityToWalk(Directions.Right);
                    walkingRight.Begin(this);
                }
            }
        }
    }
}
