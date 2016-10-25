using MarioGame.Entities;

namespace MarioGame.States
{
    class FallingMarioState : MarioActionState
    {
        //TODO: Shouldn't this state only be able to be called when in Giant Mario Power State?
        public FallingMarioState(Mario entity, MarioActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            actionState = MarioActionStateEnum.Falling; // what sprite should we use for falling?
        }
        public override void Begin(MarioActionState prevState)
        {
            _mario.ChangeActionState(stateMachine.FallingMarioState);
            _mario.SetVelocityToFalling();
        }
        public override void Jump()
        {
            stateMachine.IdleMarioState.Begin(this);
        }
    }
}
