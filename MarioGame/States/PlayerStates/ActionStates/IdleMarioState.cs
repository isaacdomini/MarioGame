using MarioGame.Entities;

namespace MarioGame.States.PlayerStates
{
    class IdleMarioState : MarioActionState
    {
        public IdleMarioState(Mario entity, MarioActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            actionState = MarioActionStateEnum.Idle;
        }
        public override void Begin(MarioActionState prevState)
        {
            mario.ChangeActionState(stateMachine.IdleMarioState);
            mario.SetVelocityToIdle();
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
        public override void MoveLeft()
        {
            if (mario.isFacingLeft())
            {
                stateMachine.WalkingMarioState.Begin(this);
            }
            else if (mario.isFacingRight())
            {
                mario.turnLeft();
            }

        }
        public override void MoveRight()
        {
            // Meaning idle mario is already facing right
            if (mario.isFacingRight())
            {
                stateMachine.WalkingMarioState.Begin(this);
            }
            // Meaning mario is facing left
            else if (mario.isFacingLeft())
            {
                mario.turnRight();
            }

        }
    }
}
