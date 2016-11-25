using MarioGame.Core;
using MarioGame.Entities;

namespace MarioGame.States
{
    internal class EnemyPlayerWalkingState : EnemyPlayerActionState
    {
        //private Goomba enemyEntity;

        public EnemyPlayerWalkingState(EnemyPlayer enemyEntity, EnemyPlayerStateMachine stateMachine) : base(enemyEntity, stateMachine)
        {
            EnemyState = EnemyActionStateEnum.Walking;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            EnemyPlayer.SetVelocityToWalk();
            EnemyPlayer.ChangeActionState(StateMachine.WalkingState);
        }

        public override void JumpedOn(Sides side)
        {
            if(side == Sides.Top)
            {
                base.JumpedOn(side);
            }
        }

    }
}
