using MarioGame.Entities;
using Microsoft.Xna.Framework;

namespace MarioGame.States.EnemyStates
{
    class DeadKoopaState : KoopaActionState
    {
        public DeadKoopaState(KoopaTroopa entity) : base(entity)
        {
            enemyState = EnemyActionStateEnum.Dead;
        }
        public override void Halt()
        {
            KoopaActionState newState = new DeadKoopaState(enemyEntity);
            newState.setDirection(this.direction);
            enemyEntity.ChangeActionState(newState);
            if (Vector2.Equals(enemyEntity._velocity,KoopaTroopaEntity.idleVelocity))
            {
                enemyEntity.SetVelocityToMoving();
            }else
            {
                enemyEntity.SetVelocityToIdle();
            }
            enemyEntity.Update();
            newState.Begin(this);
        }
    }
}
