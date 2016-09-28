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
    class DyingMarioState  : MarioActionState
    {
        //TODO: Shouldn't this state only be able to be called when in Giant Mario Power State?
        public DyingMarioState(MarioEntity entity) : base(entity)
        {
            actionState = MarioActionStates.Dead;
        }
        public override void Jump()
        {
            ActionState newState = new IdleMarioState(marioEntity);
            newState.setDirection(this.direction);
            marioEntity.ChangeState(newState);
            marioEntity.SetVelocityToIdle();
            newState.Begin(this);
        }
    }
}
