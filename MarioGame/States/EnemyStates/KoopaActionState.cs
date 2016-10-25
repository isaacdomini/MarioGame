using MarioGame.Entities;

namespace MarioGame.States
{
    public class KoopaActionState : EnemyActionState
    {
        public EnemyActionStateEnum enemyState
        { get; protected set; }
        public KoopaTroopa koopa;
        protected KoopaStateMachine _stateMachine;
        public KoopaActionState(KoopaTroopa entity, KoopaStateMachine stateMachine) : base(entity)
        {
            _stateMachine = stateMachine;
            koopa = entity;
        }

        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
        }

        public override void ChangeToDead()
        {
            _stateMachine.DeadState.Begin(this);
        }
        public void changeSpriteDirection()
        {
            if (koopa.isFacingRight())
            {
                koopa.turnLeft();
            }
            else
            {
                koopa.turnRight();
            }
        }
    }
}
