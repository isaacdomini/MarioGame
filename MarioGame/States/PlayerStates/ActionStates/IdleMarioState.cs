﻿using System;
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
            actionState = MarioActionStates.Idle;
        }

        public override void Jump()
        {
            MarioActionState jumpState = new JumpingMarioState(marioEntity);
            marioEntity.ChangeActionState(jumpState);
            jumpState.setDirection(this.direction);
            marioEntity.setVelocity(MarioEntity.jumpingUpVelocity);
            jumpState.Begin(this);

        }
        public override void Crouch()
        {
            MarioActionState crouchState = new CrouchingMarioState(marioEntity);
            marioEntity.ChangeActionState(crouchState);
            crouchState.setDirection(this.direction);
            marioEntity.setVelocity(MarioEntity.idleVelocity);
            crouchState.Begin(this);
        }
        public override void MoveLeft()
        {
            if (this.direction == Directions.Left)
            {
                MarioActionState moveLeft = new WalkingMarioState(marioEntity);
                marioEntity.ChangeActionState(moveLeft);
                moveLeft.setDirection(this.direction);
                marioEntity.setVelocity(MarioEntity.walkingLeftVelocity);
                moveLeft.Begin(this);
            }
            else if (this.direction == Directions.Right)
            {
                MarioActionState idleLeft = new IdleMarioState(marioEntity);
                marioEntity.ChangeActionState(idleLeft);
                idleLeft.setDirection(Directions.Left);
                marioEntity.setVelocity(MarioEntity.idleVelocity);
                idleLeft.Begin(this);
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
                marioEntity.setVelocity(MarioEntity.walkingRightVelocity);
                moveRight.Begin(this);
            }
            // Meaning marion is facing left
            else if (this.direction == Directions.Left)
            {
                // Mario is idling facing the right
                MarioActionState idleLeft = new IdleMarioState(marioEntity);
                marioEntity.ChangeActionState(idleLeft);
                idleLeft.setDirection(Directions.Left);
                marioEntity.setVelocity(MarioEntity.idleVelocity);
                idleLeft.Begin(this);
            }

        }
    }
}
