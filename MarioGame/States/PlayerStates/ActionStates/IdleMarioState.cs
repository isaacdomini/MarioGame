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
        public override void Fall()
        {
            stateMachine.FallingMarioState.Begin(this);
        }
        public override void MoveLeft()
        {
            if (_mario.isFacingLeft())
            {
                stateMachine.WalkingMarioState.Begin(this);
            } else if (_mario.isFacingRight())
            {
                _mario.turnLeft();
            }
        }
        public override void MoveRight()
        {
            if (_mario.isFacingLeft())
            {
                _mario.turnRight();
            } else if (_mario.isFacingRight())
            {
                stateMachine.WalkingMarioState.Begin(this);
            }
        }
    }
}
