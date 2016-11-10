using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class PirahnaStateMachine
    {
        internal PirahnaActionState DeadState { get; }
        internal PirahnaActionState AliveState { get; }

        public PirahnaStateMachine(Pirahna pirahna)
        {
            DeadState = new PirahnaDeadState(pirahna, this);
            AliveState = new PirahnaAliveState(pirahna, this);

        }
    }
}
