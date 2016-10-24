using MarioGame.Entities;

namespace MarioGame.States
{
    public class GoombaActionState : EnemyActionState
    {
        public EnemyActionStateEnum enemyState
        { get; protected set; }
        protected Goomba goomba;
        protected GoombaStateMachine _stateMachine;
        public GoombaActionState(Goomba entity, GoombaStateMachine stateMachine) : base(entity)
        {
            _stateMachine = stateMachine;
            goomba = entity;
        }

        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
        }
        public override void ChangeToDead()
        {
            _stateMachine.DeadGoomba.Begin(this);
        }
    }
}
