using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities.EnemyEntities;
using MarioGame.Entities;

namespace MarioGame.States.EnemyStates
{
    class WalkingKoopaState : KoopaActionState
    {
        //private KoopaTroopaEntity enemyEntity;

        public WalkingKoopaState(KoopaTroopaEntity enemyEntity) : base(enemyEntity)
        {
            enemyState = EnemyActionStateEnum.Walking;
        }

        public override void ChangeToDead()
        {
            KoopaActionState dead = new DeadKoopaState(enemyEntity);
            enemyEntity.ChangeActionState(dead);
            dead.Begin(this);
        }
    }
}
