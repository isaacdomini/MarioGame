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
            actionState = MarioActionStates.Idle;
        }

        public override void Jump()
        {
            ActionState jumpState = new JumpingMarioState(marioEntity);
            marioEntity.ChangeActionState(jumpState);
            jumpState.Begin(this);

        }
        public override void Crouch()
        {
            ActionState crouchState = new DyingMarioState(marioEntity);
            marioEntity.ChangeActionState(crouchState);
            crouchState.Begin(this);
        }
        public override void MoveLeft()
        {
            
        }
    }
}
