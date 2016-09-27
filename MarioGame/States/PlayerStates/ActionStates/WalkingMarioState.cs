using MarioGame.Entities;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.PlayerStates
{
    class WalkingMarioState  : MarioActionState
    {
        //TODO: Shouldn't this state only be able to be called when in Giant Mario Power State?
        public WalkingMarioState(MarioEntity entity) : base(entity)
        {
            actionState = MarioActionStates.Walking;
        }

        public override void Jump()
        {
            MarioActionState jumpState = new JumpingMarioState(marioEntity);
            marioEntity.ChangeActionState(jumpState);
            jumpState.setDirection(this.direction);
            jumpState.Begin(this);

        }
        public override void Crouch()
        {
            MarioActionState crouchState = new CrouchingMarioState(marioEntity);
            marioEntity.ChangeActionState(crouchState);
            crouchState.setDirection(this.direction);
            crouchState.Begin(this);
        }
        public override void MoveLeft()
        {
            if (this.direction == Directions.Left)
            {
                MarioActionState moveLeft = new WalkingMarioState(marioEntity);
                marioEntity.ChangeActionState(moveLeft);
                moveLeft.setDirection(Directions.Left);
                moveLeft.Begin(this);
            }
            else if (this.direction == Directions.Right)
            {
                MarioActionState idleRight = new IdleMarioState(marioEntity);
                marioEntity.ChangeActionState(idleRight);
                idleRight.setDirection(Directions.Right);
                idleRight.Begin(this);
            }

        }
        public override void MoveRight()
        {
            // Meaning idle mario is already facing right
            if (this.direction == Directions.Right)
            {
                // Mario state is set to walking right
                MarioActionState moveRight = new WalkingMarioState(marioEntity);
                marioEntity.ChangeActionState(moveRight);
                moveRight.setDirection(Directions.Right);
                moveRight.Begin(this);
            }
            // Meaning mario is facing left walking
            else if (this.direction == Directions.Left)
            {
                // Mario now is idles left
                MarioActionState idleLeft = new IdleMarioState(marioEntity);
                marioEntity.ChangeActionState(idleLeft);
                idleLeft.setDirection(Directions.Left);
                idleLeft.Begin(this);
            }
        }
    }
}
