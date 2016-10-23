using MarioGame.Entities;

namespace MarioGame.States
{
    class CrouchingMarioState : MarioActionState
    {
        //TODO: Shouldn't this state only be able to be called when in Giant Mario Power State?
        public CrouchingMarioState(Mario entity, MarioActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            actionState = MarioActionStateEnum.Crouching;
        }
        public override void Begin(MarioActionState prevState)
        {
            _mario.ChangeActionState(stateMachine.CrouchingMarioState);
            _mario.SetVelocityToFalling();
        }
        public override void Jump()
        {
            stateMachine.IdleMarioState.Begin(this);
        }
    }
}
