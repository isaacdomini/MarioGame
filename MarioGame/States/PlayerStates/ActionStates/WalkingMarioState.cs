using MarioGame.Entities;
using Microsoft.Xna.Framework;

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
            base.Begin(prevState);
        }
    }
}
