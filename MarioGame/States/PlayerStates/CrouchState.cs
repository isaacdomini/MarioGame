using MarioGame.Entities.PlayerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.PlayerStates
{
    class CrouchState  : MarioState
    {
        public CrouchState(MarioEntity entity) : base(entity)
        {

        }
        public override void Jump()
        {
            MarioState newstate = new IdleMarioState(_entity);
            _entity.ChangeState(newstate);
            newstate.Begin(this);

        }
    }
}
