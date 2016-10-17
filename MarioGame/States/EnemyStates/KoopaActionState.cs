using MarioGame.Entities;
using MarioGame.States.PlayerStates;


namespace MarioGame.States.EnemyStates
{
    public class KoopaActionState : ActionState
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

        public virtual void Begin(KoopaActionState prevState)
        {
            base.Begin(prevState);
        }
        public virtual void Halt()
        {
            ChangeToDead();
        }
        public virtual void JumpedOn()
        {
            ChangeToDead();
        }

        public virtual void ChangeToDead()
        {
            _stateMachine.DeadState.Begin(this);
        }
    }
}
