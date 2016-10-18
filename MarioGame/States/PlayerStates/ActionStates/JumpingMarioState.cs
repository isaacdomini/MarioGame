using MarioGame.Entities;
namespace MarioGame.States
{
    class JumpingMarioState : MarioActionState
    {
        public JumpingMarioState(Mario entity, MarioActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            actionState = MarioActionStateEnum.Jumping;
        }
        //TODO: need to add in behavior for jumping higher if you hold the jump button down.
        public override void Begin(MarioActionState prevState)
        {
            mario.ChangeActionState(stateMachine.JumpingMarioState);
            mario.SetVelocityToJumping();
        }
        public override void Fall()
        {
            Crouch();
        }

        public override void Crouch()
        {
            stateMachine.IdleMarioState.Begin(this);
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
            if (mario.isFacingLeft())
            {
                mario.turnRight();
            }
            else if (mario.isFacingRight())
            {
                stateMachine.WalkingMarioState.Begin(this);
            }
        }
    }
}
