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
        MarioActionState crouchingMarioState;
        MarioActionState idleMarioState;
        MarioActionState jumpMarioState;
        MarioActionState runMarioState;
        MarioActionState walkMarioState;
        MarioActionState fallingMarioState;


        internal MarioActionState CrouchingMarioState
        {
            get { return crouchingMarioState; }
        }
        internal MarioActionState IdleMarioState
        {
            get { return idleMarioState; }
        }
        internal MarioActionState WalkingMarioState
        {
            get { return walkMarioState; }
        }
        internal MarioActionState RunningMarioState
        {
            get { return runMarioState; }
        }
        internal MarioActionState JumpingMarioState
        {
            get { return jumpMarioState; }
        }
        internal MarioActionState FallingMarioState
        {
            get { return fallingMarioState; }
        }


        Mario _mario;
        public MarioActionStateMachine(Mario mario)
        {
            _mario = mario;
            walkMarioState = new WalkingMarioState(_mario, this);
            runMarioState = new RunningMarioState(_mario, this);
            jumpMarioState = new JumpingMarioState(_mario, this);
            crouchingMarioState = new CrouchingMarioState(_mario, this);
            idleMarioState = new IdleMarioState(_mario, this);
            fallingMarioState = new FallingMarioState(_mario, this);
        }
    }
}
