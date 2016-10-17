using MarioGame.Entities;

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
