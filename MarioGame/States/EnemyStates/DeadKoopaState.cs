using MarioGame.Entities.EnemyEntities;
using MarioGame.States.PlayerStates;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.EnemyStates
{
    class DeadKoopaState : KoopaActionState
    {
        public DeadKoopaState(KoopaTroopaEntity entity) : base(entity)
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
