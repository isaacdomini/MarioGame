using MarioGame.Entities;

namespace MarioGame.States
{
    internal class IdleMarioState : MarioActionState
    {
        public IdleMarioState(Mario entity, MarioActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            actionState = MarioActionStateEnum.Idle;
        }
        public override void Begin(MarioActionState prevState)
        {
            Mario.ChangeActionState(StateMachine.IdleMarioState);
            Mario.SetVelocityToIdle();
            base.Begin(prevState);
        }
        public override void Fall()
        {
            base.Fall();
            StateMachine.FallingMarioState.Begin(this);
        }
        public override void MoveLeft()
        {
            if (Mario.FacingLeft) { 
                StateMachine.WalkingMarioState.Begin(this);
            } else if (Mario.FacingRight)
            {
                Mario.TurnLeft();
            }
        }
        public override void MoveRight()
        {
            if (Mario.FacingLeft)
            {
                Mario.TurnRight();
            } else if (Mario.FacingRight)
            {
                StateMachine.WalkingMarioState.Begin(this);
            }
        }
    }
}
