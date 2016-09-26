using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Entities;

namespace MarioGame.States.PlayerStates
{
    class IdleMarioState : ActionState
    {
        public IdleMarioState(MarioEntity entity) : base(entity)
        {
            
        }
        public override void Jump()
        {
            ActionState jumpState = new JumpingMarioState(marioEntity);
            marioEntity.ChangeActionState(jumpState);
            jumpState.Begin(this);

        }
        public override void Crouch()
        {
            ActionState crouchState = new CrouchingMarioState(marioEntity);
            marioEntity.ChangeActionState(crouchState);
            crouchState.Begin(this);
        }
        public override void MoveLeft()
        {
            
        }
    }
}
