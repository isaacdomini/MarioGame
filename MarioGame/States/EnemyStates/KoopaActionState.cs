using MarioGame.Entities;

namespace MarioGame.States
{
    public class KoopaActionState : EnemyActionState
    {
        public EnemyActionStateEnum EnemyState
        { get; protected set; }

        private KoopaTroopa _koopa;
        public KoopaTroopa Koopa => _koopa;
        private KoopaStateMachine _stateMachine;
        protected KoopaStateMachine StateMachine => _stateMachine;
        public KoopaActionState(KoopaTroopa entity, KoopaStateMachine stateMachine) : base(entity)
        {
            _stateMachine = stateMachine;
            _koopa = entity;
        }

        public virtual void HitByMarioSide()
        {
           
        }
    }
}
