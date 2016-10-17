using MarioGame.Entities;

namespace MarioGame.States.PlayerStates
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
            mario.ChangeActionState(stateMachine.WalkingMarioState);
            mario.SetVelocityToWalk();
        }

        public override void Jump()
        {
            stateMachine.JumpingMarioState.Begin(this);
        }
        public override void Crouch()
        {
            stateMachine.CrouchingMarioState.Begin(this);
        }
        public override void MoveLeft()
        {
            if (mario.isFacingRight())
            {
                stateMachine.IdleMarioState.Begin(this);
            }

        }
        public override void MoveRight()
        {
            if (mario.isFacingLeft())
            {
                stateMachine.IdleMarioState.Begin(this);
            }
        }
    }
}
