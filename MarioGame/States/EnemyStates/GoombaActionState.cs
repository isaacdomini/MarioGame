using MarioGame.Entities;

namespace MarioGame.States
{
    public class GoombaActionState : EnemyActionState
    {
        public EnemyActionStateEnum EnemyState
        { get; protected set; }
        protected Goomba Goomba;
        protected GoombaStateMachine StateMachine;
        public GoombaActionState(Goomba entity, GoombaStateMachine stateMachine) : base(entity)
        {
            StateMachine = stateMachine;
            Goomba = entity;
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
