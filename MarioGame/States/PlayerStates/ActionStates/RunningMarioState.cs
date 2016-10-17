﻿using MarioGame.Entities;

namespace MarioGame.States.PlayerStates
{
    class RunningMarioState : MarioActionState
    {
        //TODO: Shouldn't this state only be able to be called when in Giant Mario Power State?
        public RunningMarioState(Mario entity, MarioActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            actionState = MarioActionStateEnum.Running;
        }
    }
}
