using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;

namespace MarioGame.States.PlayerStates.ActionStates
{
    class WalkingState : ActionState
    {
        public WalkingState(IEntity entity) : base(entity)
        {
        }
    }
}
