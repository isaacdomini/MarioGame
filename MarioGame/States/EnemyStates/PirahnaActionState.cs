using MarioGame.Entities;

namespace MarioGame.States
{
    public class PirahnaActionState : EnemyActionState
    {
        public EnemyActionStateEnum EnemyState
        { get; protected set; }

        private Pirahna _pirahna;
        protected Pirahna Pirahna => _pirahna;
        private PirahnaStateMachine _stateMachine;
        protected PirahnaStateMachine StateMachine => _stateMachine;
        public PirahnaActionState(Pirahna entity, PirahnaStateMachine stateMachine) : base(entity)
        {
            _stateMachine = stateMachine;
            _pirahna = entity;
        }

        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
        }
        public override void ChangeToDead()
        {
            StateMachine.DeadState.Begin(this);
        }
    }
}
