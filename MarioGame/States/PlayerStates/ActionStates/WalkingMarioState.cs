using MarioGame.Entities;

namespace MarioGame.States
{
    class WalkingMarioState : MarioActionState
    {
        //TODO: Shouldn't this state only be able to be called when in Giant Mario Power State?
        public WalkingMarioState(Mario entity, MarioActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            actionState = MarioActionStateEnum.Walking;
        }
        public override void Begin(MarioActionState prevState)
        {
            _mario.ChangeActionState(stateMachine.WalkingMarioState);
            _mario.SetVelocityToWalk();
        }

        public override void Jump()
        {
            stateMachine.JumpingMarioState.Begin(this);
        }
        public override void Crouch()
        {
            stateMachine.CrouchingMarioState.Begin(this);
        }
    }
}
