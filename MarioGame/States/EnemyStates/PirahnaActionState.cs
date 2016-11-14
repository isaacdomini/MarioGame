using MarioGame.Entities;

namespace MarioGame.States
{
    public class PirahnaActionState : EnemyActionState
    {
        public EnemyActionStateEnum EnemyState
        { get; protected set; }

        protected Pirahna Pirahna => (Pirahna) Entity;
        private PirahnaStateMachine _stateMachine;
        protected PirahnaStateMachine StateMachine => _stateMachine;
        public PirahnaActionState(Pirahna entity, PirahnaStateMachine stateMachine) : base(entity)
        {
            _stateMachine = stateMachine;
        }

        public override void ChangeToDead()
        {
            StateMachine.DeadState.Begin(this);
        }
    }
}
