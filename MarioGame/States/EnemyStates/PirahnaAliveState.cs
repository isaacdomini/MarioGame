using MarioGame.Core;
using MarioGame.Entities;

namespace MarioGame.States
{
    internal class PirahnaAliveState : PirahnaActionState
    {

        public PirahnaAliveState(Pirahna enemyEntity, PirahnaStateMachine stateMachine) : base(enemyEntity, stateMachine)
        {
            EnemyState = EnemyActionStateEnum.Walking;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Pirahna.SetVelocityToIdle();
            Pirahna.ChangeActionState(StateMachine.AliveState);
        }

        public override void JumpedOn(Sides side)
        {
            if (side == Sides.Top)
            {
                base.JumpedOn(side);
            }
        }

    }
}
