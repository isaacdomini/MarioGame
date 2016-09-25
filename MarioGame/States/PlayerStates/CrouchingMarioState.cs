using MarioGame.Entities.PlayerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.PlayerStates
{
    class CrouchingMarioState  : MarioState
    {
        public CrouchingMarioState(MarioEntity entity) : base(entity)
        {

        }
        public override void Jump()
        {
            MarioState newState = new IdleMarioState(_entity);
            _entity.ChangeState(newState);
            newState.Begin(this);
        }
    }
}
