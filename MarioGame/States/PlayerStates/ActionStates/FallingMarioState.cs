using MarioGame.Entities;
using System;

namespace MarioGame.States
{
    internal class FallingMarioState : MarioActionState
    {
        //TODO: Shouldn't this state only be able to be called when in Giant Mario Power State?
        public FallingMarioState(Mario entity, MarioActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            actionState = MarioActionStateEnum.Falling; // what sprite should we use for falling?
        }
        public override void Begin(MarioActionState prevState)
        {
            Mario.ChangeActionState(StateMachine.FallingMarioState);
            base.Begin(prevState);
            //Mario.SetVelocityToFalling();
        }
        public override void Jump()
        {
            //StateMachine.IdleMarioState.Begin(this);
        }

    }
}
