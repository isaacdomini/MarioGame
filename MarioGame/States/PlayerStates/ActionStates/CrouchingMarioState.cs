using MarioGame.Entities;

namespace MarioGame.States.PlayerStates
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
            mario.ChangeActionState(stateMachine.CrouchingMarioState);
            mario.SetVelocityToFalling();
        }
        public override void Jump()
        {
            stateMachine.IdleMarioState.Begin(this);
        }
    }
}
