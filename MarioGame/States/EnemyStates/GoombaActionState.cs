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

        public virtual void Begin(GoombaActionState prevState)
        {
            base.Begin(prevState);
        }
        public override void ChangeToDead()
        {
            _stateMachine.DeadGoomba.Begin(this);
        }
    }
}
