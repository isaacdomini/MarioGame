using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities.EnemyEntities;
using MarioGame.Entities;

namespace MarioGame.States.EnemyStates
{
    class WalkingGoombaState : GoombaActionState
    {
        private GoombaEntity enemyEntity;

        public WalkingGoombaState(GoombaEntity enemyEntity) : base(enemyEntity)
        {
            enemyState = EnemyActionStateEnum.Walking;
        }

        public override void ChangeToDead()
        {
            GoombaActionState dead = new DeadGoombaState(enemyEntity);
            //enemyEntity.ChangeActionState(dead);
            dead.Begin(this);
        }
    }
}
