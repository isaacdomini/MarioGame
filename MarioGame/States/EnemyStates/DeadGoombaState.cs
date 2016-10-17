using MarioGame.Entities;
using MarioGame.Entities.EnemyEntities;

namespace MarioGame.States.EnemyStates
{
    class DeadGoombaState : GoombaActionState
    {
        public DeadGoombaState(Goomba entity) : base(entity)
        {
            enemyState = EnemyActionStateEnum.Dead;
        }
    }
}
