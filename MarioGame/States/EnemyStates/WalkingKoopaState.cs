using MarioGame.Entities;


namespace MarioGame.States
{
    class WalkingKoopaState : KoopaActionState
    {
        //private KoopaTroopaEntity enemyEntity;

        public WalkingKoopaState(KoopaTroopa enemyEntity, KoopaStateMachine stateMachine) : base(enemyEntity, stateMachine)
        {
            enemyState = EnemyActionStateEnum.Walking;
        }

        public override void Begin(IState prevState)
        {
            koopa.SetVelocityToWalk();
            koopa.ChangeActionState(_stateMachine.WalkState);
        }
    }
}
