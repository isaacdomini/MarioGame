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
            Mario.ChangeActionState(StateMachine.WalkingMarioState);
            Mario.SetVelocityToWalk();
        }

        public override void MoveLeft()
        {
            if (Mario.FacingRight)
            {
                StateMachine.IdleMarioState.Begin(this);
            }
        }
        public override void MoveRight()
        {
            if (Mario.FacingLeft)
            {
                StateMachine.IdleMarioState.Begin(this);
            }
        }
    }
}
