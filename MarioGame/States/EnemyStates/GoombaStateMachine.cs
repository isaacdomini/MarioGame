using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class GoombaStateMachine
    {
        internal GoombaActionState DeadState { get; }
        internal GoombaActionState WalkingState { get; }

        public GoombaStateMachine(Goomba goomba)
        {
            DeadState = new GoombaDeadState(goomba, this);
            WalkingState = new GoombaWalkingState(goomba, this);

        }
    }
}
