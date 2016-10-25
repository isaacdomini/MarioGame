using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class MarioActionStateMachine
    {
        internal MarioActionState CrouchingMarioState { get; }

        internal MarioActionState IdleMarioState { get; }

        internal MarioActionState WalkingMarioState { get; }

        internal MarioActionState RunningMarioState { get; }

        internal MarioActionState JumpingMarioState { get; }

        internal MarioActionState FallingMarioState { get; }


        public MarioActionStateMachine(Mario mario)
        {
            var mario1 = mario;
            WalkingMarioState = new WalkingMarioState(mario1, this);
            RunningMarioState = new RunningMarioState(mario1, this);
            JumpingMarioState = new JumpingMarioState(mario1, this);
            CrouchingMarioState = new CrouchingMarioState(mario1, this);
            IdleMarioState = new IdleMarioState(mario1, this);
            FallingMarioState = new FallingMarioState(mario1, this);
        }
    }
}
