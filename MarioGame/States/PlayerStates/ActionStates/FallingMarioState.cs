using MarioGame.Entities;

namespace MarioGame.States
{
    class FallingMarioState : MarioActionState
    {
        //TODO: Shouldn't this state only be able to be called when in Giant Mario Power State?
        public FallingMarioState(Mario entity, MarioActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            actionState = MarioActionStateEnum.Crouching; // what sprite should we use for falling?
        }
        public override void Begin(MarioActionState prevState)
        {
            mario.ChangeActionState(stateMachine.FallingMarioState);
            mario.SetVelocityToFalling();
        }
        public override void Jump()
        {
            stateMachine.IdleMarioState.Begin(this);
        }
        public override void MoveLeft()
        {
            if (mario.isFacingRight())
            {
                mario.turnLeft();
                mario.SetVelocityToIdle();
            }
            else if (mario.isFacingLeft())
            {
                stateMachine.WalkingMarioState.Begin(this);
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
