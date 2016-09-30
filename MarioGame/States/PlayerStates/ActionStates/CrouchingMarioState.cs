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
    class CrouchingMarioState  : MarioActionState
    {
        //TODO: Shouldn't this state only be able to be called when in Giant Mario Power State?
        public CrouchingMarioState(MarioEntity entity) : base(entity)
        {
            actionState = MarioActionStateEnum.Crouching;
        }
        public override void Jump()
        {
            MarioActionState newState = new IdleMarioState(marioEntity);
            newState.setDirection(this.direction);
            marioEntity.ChangeActionState(newState);
            marioEntity.SetVelocityToIdle();
            newState.Begin(this);
        }
        public override void Crouch()
        {
            MarioActionState fallingState = new FallingMarioState(marioEntity);
            fallingState.setDirection(this.direction);
            marioEntity.ChangeActionState(fallingState);
            marioEntity.SetVelocityToFalling();
            fallingState.Begin(this);
        }
    }
}
