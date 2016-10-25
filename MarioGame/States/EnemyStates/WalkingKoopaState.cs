using MarioGame.Entities;


namespace MarioGame.States
{
    internal class WalkingKoopaState : KoopaActionState
    {
        //private KoopaTroopaEntity enemyEntity;

        public WalkingKoopaState(KoopaTroopa enemyEntity, KoopaStateMachine stateMachine) : base(enemyEntity, stateMachine)
        {
            EnemyState = EnemyActionStateEnum.Walking;
        }

        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Koopa.SetVelocityToWalk();
            Koopa.ChangeActionState(StateMachine.WalkState);
        }
        
    }
}
