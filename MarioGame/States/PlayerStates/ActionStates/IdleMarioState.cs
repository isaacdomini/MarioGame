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
            base.Fall();
            stateMachine.FallingMarioState.Begin(this);
        }
        public override void MoveLeft()
        {
            if (_mario.FacingLeft) { 
                stateMachine.WalkingMarioState.Begin(this);
            } else if (_mario.FacingRight)
            {
                _mario.turnLeft();
            }
        }
        public override void MoveRight()
        {
            if (_mario.FacingLeft)
            {
                _mario.turnRight();
            } else if (_mario.FacingRight)
            {
                stateMachine.WalkingMarioState.Begin(this);
            }
        }
    }
}
