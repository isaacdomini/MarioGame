using MarioGame.Entities;
using Microsoft.Xna.Framework;

namespace MarioGame.States
{
    class DeadKoopaState : KoopaActionState
    {
        public DeadKoopaState(KoopaTroopa entity, KoopaStateMachine stateMachine) : base(entity, stateMachine)
        {
            enemyState = EnemyActionStateEnum.Dead;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            koopa.SetVelocityToIdle();
            koopa.ChangeActionState(_stateMachine.DeadState);
        }
        public override void JumpedOn()
        {
            //KoopaTroopa.shellMovingVelocity= new Vector2(-2, 0);
            _stateMachine.BouncingState.Begin(this);
        }
    }
}
