using MarioGame.Entities;
using MarioGame.Entities.EnemyEntities;

namespace MarioGame.States.EnemyStates
{
    class WalkingGoombaState : GoombaActionState
    {
        //private Goomba enemyEntity;

        public WalkingGoombaState(Goomba enemyEntity) : base(enemyEntity)
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
