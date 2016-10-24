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
        public override void Begin(KoopaActionState prevState)
        {
            koopa.SetVelocityToIdle();
            koopa.ChangeActionState(_stateMachine.DeadState);
        }
        public override void JumpedOn()
        {
            _stateMachine.BouncingState.Begin(this);
        }
    }
}
