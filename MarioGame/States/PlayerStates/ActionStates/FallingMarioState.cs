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
    class FallingMarioState  : MarioActionState
    {
        //TODO: Shouldn't this state only be able to be called when in Giant Mario Power State?
        public FallingMarioState(MarioEntity entity) : base(entity)
        {
            actionState = MarioActionStateEnum.Idle; // what sprite should we use for falling?
        }
        public override void Jump()
        {
            MarioActionState idleMario = new IdleMarioState(marioEntity);
            idleMario.setDirection(this.direction);
            marioEntity.ChangeActionState(idleMario);
            marioEntity.SetVelocityToIdle();
            idleMario.Begin(this);
        }
        public override void MoveLeft()
        {
            if (this.direction == Directions.Right)
            {
                MarioActionState fallingFacingLeft = new FallingMarioState(marioEntity);
                marioEntity.ChangeActionState(fallingFacingLeft);
                fallingFacingLeft.setDirection(Directions.Left);
                marioEntity.setVelocity(MarioEntity.FallingVelocity);
                fallingFacingLeft.Begin(this);
            }
            else if (this.direction == Directions.Left)
            {
                MarioActionState walkingLeft = new WalkingMarioState(marioEntity);
                marioEntity.ChangeActionState(walkingLeft);
                walkingLeft.setDirection(Directions.Left);
                marioEntity.setVelocity(MarioEntity.walkingLeftVelocity);
                walkingLeft.Begin(this);

            }
        }
        public override void MoveRight()
        {
            if (this.direction == Directions.Left)
            {
                MarioActionState fallingFacingRight = new FallingMarioState(marioEntity);
                marioEntity.ChangeActionState(fallingFacingRight);
                fallingFacingRight.setDirection(Directions.Right);
                marioEntity.setVelocity(MarioEntity.FallingVelocity);
                fallingFacingRight.Begin(this);
            }
            else if (this.direction == Directions.Right)
            {
                MarioActionState walkingRight = new WalkingMarioState(marioEntity);
                marioEntity.ChangeActionState(walkingRight);
                walkingRight.setDirection(Directions.Right);
                marioEntity.setVelocity(MarioEntity.walkingRightVelocity);
                walkingRight.Begin(this);

            }
        }
    }
}
