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
            actionState = MarioActionStates.Idle; // what sprite should we use for falling?
        }
    }
}
