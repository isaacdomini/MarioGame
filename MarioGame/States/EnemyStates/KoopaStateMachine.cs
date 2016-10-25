using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class KoopaStateMachine
    {
        internal KoopaActionState DeadState { get; }

        internal KoopaActionState WalkingState { get; }

        internal KoopaBouncingState BouncingState { get; }

        public KoopaStateMachine(KoopaTroopa koopa)
        {
            DeadState = new KoopaDeadState(koopa, this);
            WalkingState = new KoopaWalkingState(koopa, this);
            BouncingState = new KoopaBouncingState(koopa, this);
        }

    }
}
