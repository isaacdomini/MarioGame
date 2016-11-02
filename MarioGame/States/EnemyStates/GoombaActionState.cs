using MarioGame.Entities;

namespace MarioGame.States
{
    public class GoombaActionState : EnemyActionState
    {
        public EnemyActionStateEnum EnemyState
        { get; protected set; }

        private Goomba _goomba;
        protected Goomba Goomba => _goomba;
        private GoombaStateMachine _stateMachine;
        protected GoombaStateMachine StateMachine => _stateMachine;
        public GoombaActionState(Goomba entity, GoombaStateMachine stateMachine) : base(entity)
        {
            _stateMachine = stateMachine;
            _goomba = entity;
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
