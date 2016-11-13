using MarioGame.Entities;

namespace MarioGame.States
{
    internal class CrouchingMarioState : MarioActionState
    {
        //TODO: Shouldn't this state only be able to be called when in Giant Mario Power State?
        public CrouchingMarioState(Mario entity, MarioActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            actionState = MarioActionStateEnum.Crouching;
        }
        public override void Begin(MarioActionState prevState)
        {
            Mario.ChangeActionState(StateMachine.CrouchingMarioState);
            Mario.SetVelocityToFalling();
            base.Begin(prevState);
        }
        public override void Jump()
        {
            StateMachine.IdleMarioState.Begin(this);
        }

        public override void HitTopOfGreenPipe()
        {
            Mario.GoToHiddenRoom();
        }
    }
}
