using MarioGame.Entities.EnemyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.EnemyStates
{
    class DeadGoombaState : GoombaActionState
    {
        public DeadGoombaState(GoombaEntity entity) : base(entity)
        {
            enemyState = EnemyActionStateEnum.Dead;
        }

        public override void Halt()
        {
        }
    }
}
