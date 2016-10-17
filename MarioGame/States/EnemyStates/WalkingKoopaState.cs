using MarioGame.Entities;


namespace MarioGame.States.EnemyStates
{
    class WalkingKoopaState : KoopaActionState
    {
        //private KoopaTroopaEntity enemyEntity;

        public WalkingKoopaState(KoopaTroopa enemyEntity) : base(enemyEntity)
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
