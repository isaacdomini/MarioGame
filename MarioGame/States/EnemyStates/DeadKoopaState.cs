using MarioGame.Entities.EnemyEntities;
using MarioGame.States.PlayerStates;
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
    }
}
