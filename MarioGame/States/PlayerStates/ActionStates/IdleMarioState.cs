using MarioGame.Entities;

namespace MarioGame.States
{
    class IdleMarioState : MarioActionState
    {
        public IdleMarioState(Mario entity, MarioActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            actionState = MarioActionStateEnum.Idle;
        }
        public override void Begin(MarioActionState prevState)
        {
            _mario.ChangeActionState(stateMachine.IdleMarioState);
            _mario.SetVelocityToIdle();
        }

        public override void Jump()
        {
            stateMachine.JumpingMarioState.Begin(this);
        }
        public override void Crouch()
        {
            stateMachine.CrouchingMarioState.Begin(this);
        }
        public override void Fall()
        {
            stateMachine.FallingMarioState.Begin(this);
        }
    }
}
