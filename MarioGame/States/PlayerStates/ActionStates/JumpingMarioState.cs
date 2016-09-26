using MarioGame.Entities;
using MarioGame.Entities.PlayerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.PlayerStates
{
    class JumpingMarioState : MarioActionState
    {
        public JumpingMarioState(MarioEntity entity) : base(entity)
        {
            actionState = MarioActionStates.Jumping;
        }
        //TODO: need to add in behavior for jumping higher if you hold the jump button down.
    }
}
